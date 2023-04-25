using System.Security.Claims;
using Main.Application.Interfaces;
using Main.Application.Models;
using Microsoft.AspNetCore.Identity;

namespace Main.Services;

public class LoginService : ILoginService<User>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginService(UserManager<User> userManager, SignInManager<User> signInManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> ValidateCredentials(string? email, string? password = null, bool checkPassword = false)
    {
        if (await FindByEmail(email) is not { } user)
            return false;

        if (checkPassword &&
            !(await _signInManager.CheckPasswordSignInAsync(user,
                password ?? throw new Exception("Password not provided"), true)).Succeeded)
            return false;

        return true;
    }

    public async Task<User?> FindByEmail(string? email) =>
        await _userManager.FindByEmailAsync(email ?? throw new Exception("Email not provided"));

    public async Task<User?> GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User ?? throw new Exception("Not logged in");
        return await FindByEmail(user.FindFirstValue(ClaimTypes.Email));
    }
}