using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser();

        if (user is null)
            return ForbidUnauthorizedClient();

        var list = new List<AddressDto>();

        user.Addresses.ForEach(a => list.Add(new AddressDto
        {
            City = a.City,
            Street = a.Street,
            House = a.House,
            Apartment = a.Apartment,
            Commentary = a.Commentary
        }));

        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress([FromBody] AddAddressDto addressDto)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        var address = new Address
        {
            City = addressDto.City,
            Street = addressDto.Street,
            House = addressDto.House,
            Apartment = addressDto.Apartment,
            Commentary = addressDto.Commentary,
            User = user
        };

        if (await _addressService.CreateAddress(address) is not { } resultAddress)
            throw new Exception("Address is not created");

        var result = new AddressDto
        {
            City = resultAddress.City,
            Street = resultAddress.Street,
            House = resultAddress.House,
            Apartment = resultAddress.Apartment,
            Commentary = resultAddress.Commentary
        };

        return Ok(result);
    }
}