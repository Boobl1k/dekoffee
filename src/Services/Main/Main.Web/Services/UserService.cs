using System.Security.Claims;
using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;

namespace Main.Services;

public class UserService : IUserService<User>, IUserBuilder<User>
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IQueryable<User> _query;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
        _query = userManager.Users;
    }

    public async Task<bool> ValidateCredentials(string email, string? password = null, bool checkPassword = false)
    {
        if (await FindByEmail(email) is not { } user)
            return false;

        if (checkPassword &&
            !(await _signInManager.CheckPasswordSignInAsync(user,
                password ?? throw new Exception("Password not provided"), true)).Succeeded)
            return false;

        return true;
    }

    public async Task<User> UpdateUser(User user)
    {
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            throw new Exception("Unable to update user");
        return (await CreateUserBuilder().FindByEmail(user.Email!))!;
    }

    public async Task BlockUnblockUser(User user, bool isBlocked)
    {
        user.IsBlocked = isBlocked;
        await UpdateUser(user);
    }

    public async Task MarkUserAsDeleted(User user)
    {
        user.IsDeleted = true;
        await UpdateUser(user);
    }

    public async Task<List<User>> GetUsers() =>
        await _query.ToListAsync();

    public IUserBuilder<User> WithCartProducts()
    {
        _query = _query.Include(u => u.Cart.Products).ThenInclude(p => p.Product);
        return this;
    }

    public async Task<User?> FindByEmail(string email) =>
        await _query.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<User?> FindById(Guid id) =>
        await _query.FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User?> GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User ?? throw new Exception("Not logged in");
        return await FindByEmail(user.FindFirstValue(OpenIddictConstants.Claims.Email) ??
                                 throw new Exception("Not logged in"));
    }

    public IUserBuilder<User> CreateUserBuilder() => this;

    public IUserBuilder<User> WithAddresses()
    {
        _query = _query.Include(u => u.Addresses);
        return this;
    }
}