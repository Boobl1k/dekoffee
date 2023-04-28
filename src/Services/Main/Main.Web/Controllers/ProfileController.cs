using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private readonly IProfileService<User> _profileService;
    private readonly ILoginService<User> _loginService;

    public ProfileController(IProfileService<User> profileService, ILoginService<User> loginService)
    {
        _profileService = profileService;
        _loginService = loginService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        if (await _loginService.FindById(id) is not { } user)
            return BadRequest();

        var profileDto = new ProfileDto
        {
            Email = user.Email ?? "",
            Username = user.UserName ?? ""
        };

        return Ok(profileDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProfile(Guid id, [FromBody] UpdateProfileDto profileDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _loginService.FindById(id) is not { } user)
            return BadRequest();

        user.UserName = profileDto.Username;
        user.Email = profileDto.Email;

        await _profileService.UpdateProfile(user);
        return NoContent();
    }
}