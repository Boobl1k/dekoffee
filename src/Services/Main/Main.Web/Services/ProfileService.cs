using Main.Application.Interfaces;
using Main.Application.Models;
using Microsoft.AspNetCore.Identity;

namespace Main.Services;

public class ProfileService : IProfileService<User>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserService<User> _userService;

    public ProfileService(UserManager<User> userManager, IUserService<User> userService)
    {
        _userManager = userManager;
        _userService = userService;
    }

    public async Task<User?> UpdateProfile(User user)
    {
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            throw new Exception("Unable to update user");
        return await _userService.CreateUserBuilder().FindByEmail(user.Email);
    }
}