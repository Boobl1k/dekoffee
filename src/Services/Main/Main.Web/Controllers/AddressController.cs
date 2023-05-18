using System.Net.Mime;
using Main.Application.Interfaces;
using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Main.Dto;
using Main.Dto.Address;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("addresses"), OpenIdDictAuthorize]
public class AddressController : CustomControllerBase
{
    private readonly IAddressService _addressService;
    private readonly IUserService<User> _userService;

    public AddressController(IAddressService addressService, IUserService<User> userService)
    {
        _addressService = addressService;
        _userService = userService;
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayAddressDto))]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetAddress([FromRoute] Guid id)
    {
        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        if (user.Addresses.FirstOrDefault(a => a.Id == id) is not { } address)
            return NotFound();

        return Ok(DisplayAddressDto.FromEntity(address));
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DisplayAddressDto>))]
    [HttpGet]
    public async Task<IActionResult> GetAddresses()
    {
        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return Unauthorized();

        return Ok(user.Addresses.Select(DisplayAddressDto.FromEntity));
    }

    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [HttpPost]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressDto addressDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        var address = addressDto.ToEntity();

        if (await _addressService.CreateAddressForUser(address, user) is not { } resultAddress)
            throw new Exception("Cannot create Address");

        return StatusCode(StatusCodes.Status201Created, resultAddress.Id);
    }

    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAddress([FromRoute] Guid id, [FromBody] UpdateAddressDto addressDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        if (user.Addresses.FirstOrDefault(a => a.Id == id) is not {} address)
            return NotFound();

        addressDto.UpdateAddress(address);
        await _addressService.UpdateAddress(address);

        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAddress([FromRoute] Guid id)
    {
        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        if (user.Addresses.FirstOrDefault(a => a.Id == id) is not { } address)
            return NotFound();

        await _addressService.DeleteAddress(address);

        return NoContent();
    }
}