using Main.Application.Models;
using Main.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data.Seed;

internal static class UserSeed
{
    public const string AdminId = "E58A4734-D89C-48EB-A65D-E0E192BDDA7C";
    public const string AdelId = "1799C9F1-E377-45FE-8858-D909D0C2F7A7";
    public const string DmitryId = "A969812B-4FC3-4FFC-B739-2A467117F64E";
    public const string RuslanId = "B1F872ED-1A8B-4D71-8694-E9273287F8EC";
    public const string MansurId = "0C3A4AC7-6FA2-4AAD-A576-48EF57B1C999";
    public const string DamirId = "780C9E97-6564-4A35-8195-9544BA50D904";

    public static void AddSeedUsers(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(GetSeedUsers());

        modelBuilder.Entity<User>().HasMany(u => u.Addresses).WithMany()
            .UsingEntity(x => x.HasData(GetSeedUserAddresses()));

        modelBuilder.Entity<User>().OwnsOne(u => u.Cart).HasData(GetSeedCarts());
        modelBuilder.Entity<User>().OwnsOne(u => u.Cart).OwnsMany(c => c.Products).HasData(GetSeedCartProducts());
    }

    private static IEnumerable<object> GetSeedUsers()
    {
        //admin
        yield return new
        {
            Id = AdminId.ToGuid(),
            UserName = "Админ",
            NormalizedUserName = "АДМИН",
            Email = "admin@dekoff.ee",
            NormalizedEmail = "ADMIN@DEFOFF.EE",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<User>().HashPassword(null!, "admin-pass"),
            SecurityStamp = "18D6AB4E-F06A-4458-B24F-33DCC663BAC9",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            IsDeleted = false,
            IsBlocked = false
        };

        //barista adel
        yield return new
        {
            Id = AdelId.ToGuid(),
            UserName = "Бариста_Адель",
            NormalizedUserName = "БАРИСТА_АДЕЛЬ",
            Email = "adel@dekoff.ee",
            NormalizedEmail = "ADEL@DEFOFF.EE",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<User>().HashPassword(null!, "adel-pass"),
            SecurityStamp = "18D6AB4E-F06A-4458-B24F-33DCC663BAC9",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            IsDeleted = false,
            IsBlocked = false
        };

        //courier dmitry
        yield return new
        {
            Id = DmitryId.ToGuid(),
            UserName = "Курьер_Дмитрий",
            NormalizedUserName = "КУРЬЕР_ДМИТРИЙ",
            Email = "courier.dmitry@dekoff.ee",
            NormalizedEmail = "COURIER.DMITRY@DEFOFF.EE",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<User>().HashPassword(null!, "dmitry-pass"),
            SecurityStamp = "18D6AB4E-F06A-4458-B24F-33DCC663BAC9",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            IsDeleted = false,
            IsBlocked = false
        };

        //courier ruslan
        yield return new
        {
            Id = RuslanId.ToGuid(),
            UserName = "Курьер_Руслан",
            NormalizedUserName = "КУРЬЕР_РУСЛАН",
            Email = "courier.ruslan@dekoff.ee",
            NormalizedEmail = "COURIER.RUSLAN@DEFOFF.EE",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<User>().HashPassword(null!, "ruslan-pass"),
            SecurityStamp = "18D6AB4E-F06A-4458-B24F-33DCC663BAC9",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            IsDeleted = false,
            IsBlocked = false
        };

        //customer mansur
        yield return new
        {
            Id = MansurId.ToGuid(),
            UserName = "Мансур",
            NormalizedUserName = "МАНСУР",
            Email = "mansur@ema.il",
            NormalizedEmail = "MANSUR@EMA.IL",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<User>().HashPassword(null!, "mansur-pass"),
            SecurityStamp = "18D6AB4E-F06A-4458-B24F-33DCC663BAC9",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            IsDeleted = false,
            IsBlocked = false
        };

        //customer damir
        yield return new
        {
            Id = DamirId.ToGuid(),
            UserName = "Дамир",
            NormalizedUserName = "ДАМИР",
            Email = "damir@ema.il",
            NormalizedEmail = "DAMIR@EMA.IL",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<User>().HashPassword(null!, "damir-pass"),
            SecurityStamp = "18D6AB4E-F06A-4458-B24F-33DCC663BAC9",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            IsDeleted = false,
            IsBlocked = false
        };
    }

    private static IEnumerable<object> GetSeedUserAddresses()
    {
        yield return new
        {
            UserId = MansurId.ToGuid(),
            AddressesId = AddressSeed.KremlevskayaId.ToGuid()
        };
        yield return new
        {
            UserId = DamirId.ToGuid(),
            AddressesId = AddressSeed.DomDamiraId.ToGuid()
        };
        yield return new
        {
            UserId = DamirId.ToGuid(),
            AddressesId = AddressSeed.DomDekoId.ToGuid()
        };
    }

    private static IEnumerable<object> GetSeedCarts()
    {
        yield return new
        {
            UserId = AdminId.ToGuid(),
        };
        yield return new
        {
            UserId = AdelId.ToGuid(),
        };
        yield return new
        {
            UserId = DmitryId.ToGuid(),
        };
        yield return new
        {
            UserId = RuslanId.ToGuid(),
        };
        yield return new
        {
            UserId = MansurId.ToGuid(),
        };
        yield return new
        {
            UserId = DamirId.ToGuid(),
        };
    }

    private static IEnumerable<object> GetSeedCartProducts()
    {
        yield return new
        {
            CartUserId = MansurId.ToGuid(),
            ProductId = ProductSeed.CappuccinoId.ToGuid(),
            Count = 2,
            Id = "C7F42CA1-40E9-4E25-BB21-59197E42EDF1".ToGuid()
        };
        yield return new
        {
            CartUserId = MansurId.ToGuid(),
            ProductId = ProductSeed.LatteId.ToGuid(),
            Count = 1,
            Id = "6395E1E5-0BFF-4182-9A21-CB0FB9A7159E".ToGuid()
        };
    }
}