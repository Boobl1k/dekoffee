using System.Security.Claims;
using System.Text.Json;
using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto.User;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;

namespace Main.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : CustomControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IUserService<User> _userService;
    private readonly ICartService _cartService;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager,
        IUserService<User> userService, ICartService cartService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userService = userService;
        _cartService = cartService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        
        if (await _userService.ValidateCredentials(registerUserDto.Email, checkPassword: false))
            return BadRequest("User with same Email already exists");

        if (registerUserDto.Password != registerUserDto.RepeatPassword)
            return BadRequest("Mismatch of passwords");
        
        var guid = Guid.NewGuid();
        var user = Mapper.Map<User>(registerUserDto);
        user.Id = guid;

        Console.WriteLine(JsonSerializer.Serialize(user));

        var result = await _userManager.CreateAsync(user, registerUserDto.Password);
        Console.WriteLine(result.Errors.FirstOrDefault()?.Description);

        if (!result.Succeeded)
            return Forbid(new AuthenticationProperties(result.Errors.ToDictionary(error => error.Code,
                error => error.Description)!));

        if (await _cartService.CreateCart(new Cart { Id = guid }) is null)
            throw new Exception("Cart is not created");

        return Ok();
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }

    [HttpPost("Login"), Consumes("application/x-www-form-urlencoded")]
    public async Task<IActionResult> Login([FromForm] LoginUserDto userDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        var request = HttpContext.GetOpenIddictServerRequest() ?? throw new Exception("OpenIdDict config is wrong");

        if (!await _userService.ValidateCredentials(userDto.Email, userDto.Password, true))
            return Forbid(new AuthenticationProperties(new Dictionary<string, string?>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = OpenIddictConstants.Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                    "Incorrect email or password"
            }), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

        var userPrincipal =
            await _signInManager.CreateUserPrincipalAsync((await _userService.CreateUserBuilder()
                .FindByEmail(userDto.Email))!);
        userPrincipal.SetScopes(new[]
        {
            OpenIddictConstants.Permissions.Scopes.Email,
            OpenIddictConstants.Permissions.Scopes.Profile,
            OpenIddictConstants.Permissions.Scopes.Roles
        }.Intersect(request.GetScopes()));
        foreach (var claim in userPrincipal.Claims)
            claim.SetDestinations(GetDestinations(claim, userPrincipal));
        return SignIn(userPrincipal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

        static IEnumerable<string> GetDestinations(Claim claim, ClaimsPrincipal principal)
        {
            switch (claim.Type)
            {
                case OpenIddictConstants.Claims.Name:
                    yield return OpenIddictConstants.Destinations.AccessToken;
                    if (principal.HasScope(OpenIddictConstants.Permissions.Scopes.Profile))
                        yield return OpenIddictConstants.Destinations.IdentityToken;
                    yield break;
                case OpenIddictConstants.Claims.Email:
                    yield return OpenIddictConstants.Destinations.AccessToken;
                    if (principal.HasScope(OpenIddictConstants.Permissions.Scopes.Email))
                        yield return OpenIddictConstants.Destinations.IdentityToken;
                    yield break;
                case OpenIddictConstants.Claims.Role:
                    yield return OpenIddictConstants.Destinations.AccessToken;
                    if (principal.HasScope(OpenIddictConstants.Permissions.Scopes.Roles))
                        yield return OpenIddictConstants.Destinations.IdentityToken;
                    yield break;
                case "AspNet.Identity.SecurityStamp":
                    yield break;
                default:
                    yield return OpenIddictConstants.Destinations.AccessToken;
                    yield break;
            }
        }
    }
}