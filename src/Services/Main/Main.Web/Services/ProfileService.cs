using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
using Main.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Main.Services;

public class ProfileService : IProfileService<User>
{
    private readonly UserManager<User> _userManager;
    private readonly AppDbContext _dbContext;
    private readonly ILoginService<User> _loginService;

    public ProfileService(UserManager<User> userManager, AppDbContext dbContext, ILoginService<User> loginService)
    {
        _userManager = userManager;
        _dbContext = dbContext;
        _loginService = loginService;
    }

    public async Task<User?> UpdateProfile(User user)
    {
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            throw new Exception("Unable to update user");
        return await _loginService.FindByEmail(user.Email);
    }
}