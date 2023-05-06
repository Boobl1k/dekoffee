using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto.Address;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]"), OpenIdDictAuthorize]
public class AddressController : CustomControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IUserService<User> _userService;

    public AddressController(IAddressService addressService, IUserService<User> userService)
    {
        _addressService = addressService;
        _userService = userService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAddress(Guid id)
    {
        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        if (user.Addresses.FirstOrDefault(a => a.Id == id) is not { } address)
            return BadRequestInvalidObject(nameof(Address));

        return Ok(Mapper.Map<DisplayAddressDto>(address));
    }

    [HttpGet]
    public async Task<IActionResult> GetAddresses()
    {
        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        var list = Mapper.Map<List<Address>, List<DisplayAddressDto>>(user.Addresses);
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressDto addressDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        var address = Mapper.Map<Address>(addressDto);
        address.User = user;

        if (await _addressService.CreateAddress(address) is not { } resultAddress)
            throw new Exception("Address is not created");

        return Ok(Mapper.Map<AddressDto>(resultAddress));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAddress([FromRoute] Guid id, [FromBody] UpdateAddressDto addressDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        if (user.Addresses.FirstOrDefault(a => a.Id == id) is not { } address)
            return BadRequestInvalidObject(nameof(Address));

        address = Mapper.Map(addressDto, address);
        await _addressService.UpdateAddress(address);

        return Ok(Mapper.Map<AddressDto>(address));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAddress([FromRoute] Guid id)
    {
        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        if (user.Addresses.FirstOrDefault(a => a.Id == id) is not { } address)
            return BadRequestInvalidObject(nameof(Address));

        await _addressService.DeleteAddress(address);

        return Ok();
    }
}