using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]"), OpenIdDictAuthorize]
public class ProfileController : CustomControllerBase
{
    private readonly IProfileService<User> _profileService;
    private readonly IUserService<User> _userService;

    public ProfileController(IProfileService<User> profileService, IUserService<User> userService)
    {
        _profileService = profileService;
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        var profileDto = new ProfileDto
        {
            Email = user.Email ?? "",
            Username = user.UserName ?? ""
        };

        return Ok(profileDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto profileDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        user.UserName = profileDto.Username;
        user.Email = profileDto.Email;

        await _profileService.UpdateProfile(user);
        return NoContent();
    }
}