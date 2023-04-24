using Microsoft.AspNetCore.Identity;

namespace Main.Application.Models;

public class User : IdentityUser<Guid>
{
    public string Password { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public bool IsBlocked { get; set; }

    public List<Address> Addresses { get; set; } = null!;
}