using Main.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data.Seed;

internal static class UserRoleSeed
{
    public static void AddSeedUserRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(GetSeedUserRoles());
    }

    private static IEnumerable<object> GetSeedUserRoles()
    {
        yield return new IdentityUserRole<Guid>
        {
            RoleId = RoleSeed.AdminId.ToGuid(),
            UserId = UserSeed.AdminId.ToGuid()
        };
        yield return new IdentityUserRole<Guid>
        {
            RoleId = RoleSeed.ExecutorId.ToGuid(),
            UserId = UserSeed.AdelId.ToGuid()
        };
        yield return new IdentityUserRole<Guid>
        {
            RoleId = RoleSeed.ExecutorId.ToGuid(),
            UserId = UserSeed.DmitryId.ToGuid()
        };
        yield return new IdentityUserRole<Guid>
        {
            RoleId = RoleSeed.ExecutorId.ToGuid(),
            UserId = UserSeed.RuslanId.ToGuid()
        };
    }
}