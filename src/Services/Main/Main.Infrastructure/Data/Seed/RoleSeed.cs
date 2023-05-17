using Main.Application.Models;
using Main.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data.Seed;

internal static class RoleSeed
{
    public const string AdminId = "697F3429-C044-46DE-AABD-1B8F801A9464";
    public const string ExecutorId = "340126FB-E9C4-4857-9033-4A1E8AF859B0";
    public static void AddSeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole<Guid>>().HasData(GetSeedRoles());
    }

    private static IEnumerable<object> GetSeedRoles()
    {
        yield return new IdentityRole<Guid>()
        {
            Id = AdminId.ToGuid(),
            Name = UserRoles.Admin,
            NormalizedName = UserRoles.Admin.ToUpper()
        };
        yield return new IdentityRole<Guid>()
        {
            Id = ExecutorId.ToGuid(),
            Name = UserRoles.Executor,
            NormalizedName = UserRoles.Executor.ToUpper()
        };
    }
}