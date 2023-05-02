using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto.User;
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
    public async Task<IActionResult> GetProfile()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();
        
        return Ok(Mapper.Map<ProfileDto>(user));
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