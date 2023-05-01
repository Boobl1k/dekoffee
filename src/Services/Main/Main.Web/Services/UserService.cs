﻿using System.Security.Claims;
using Main.Application.Interfaces;
using Main.Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpenIddict.Abstractions;

namespace Main.Services;

public class UserService : IUserService<User>, IUserBuilder<User>
{
    private readonly SignInManager<User> _signInManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private IQueryable<User> _query;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _signInManager = signInManager;
        _httpContextAccessor = httpContextAccessor;
        _query = userManager.Users;
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