using Main.Application.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Main.Application.Models;

public static class UserRoles
{
    public const string Admin = "ADMIN_ROLE";
    public const string Executor = "EXECUTOR_ROLE";
}

public class User : IdentityUser<Guid>
{
#pragma warning disable CS8765
    public sealed override string Email { get; set; }
    public sealed override string UserName { get; set; }
#pragma warning restore CS8765
    public bool IsDeleted { get; set; }
    public bool IsBlocked { get; set; }

    private readonly Cart? _cart;

    public Cart Cart
    {
        get => _cart ?? throw new UninitializedException();
        private init => _cart = value;
    }

    private List<Address>? _addresses;

    public List<Address> Addresses
    {
        get => _addresses ?? throw new UninitializedException();
        set => _addresses = value;
    }

    // ReSharper disable once UnusedMember.Local
#pragma warning disable CS8618
    private User()
#pragma warning restore CS8618
    {
    }

    public User(string email, string userName, Cart cart)
    {
        Email = email;
        UserName = userName;
        Cart = cart;
        Addresses = new List<Address>();
    }
}