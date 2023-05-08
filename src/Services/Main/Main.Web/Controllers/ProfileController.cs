﻿using System.Net.Mime;
using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
using Main.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]"), OpenIdDictAuthorize]
public class ProfileController : CustomControllerBase
{
    private readonly IUserService<User> _userService;

    public ProfileController(IUserService<User> userService)
    {
        _userService = userService;
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDto))]
    [HttpGet]
    public async Task<IActionResult> GetProfile()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        return Ok(Mapper.Map<ProfileDto>(user));
    }

    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut]
    public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto profileDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        user = Mapper.Map(profileDto, user);
        await _userService.UpdateUser(user);
        return NoContent();
    }
}