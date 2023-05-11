using Main.Application.Models;
using Main.Tools;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Data.Seed;

internal static class AddressSeed
{
    public const string KremlevskayaId = "328D54C1-BF3E-417B-9C16-1E3963F3E7A4";
    public const string DomDamiraId = "A372BB6B-2E44-4CF9-8A3C-BDBEE21B3472";
    public const string DomDekoId = "F0CA1801-3F08-4659-8151-DB84F2EE90B1";
    
    public static void AddSeedAddresses(this ModelBuilder builder)
    {
        builder.Entity<Address>().HasData(GetSeedAddresses());
    }

    private static IEnumerable<object> GetSeedAddresses()
    {
        yield return new
        {
            Id = KremlevskayaId.ToGuid(),
            City = "Казань",
            Street = "Кремлевская",
            House = "35",
            Section = 1,
            Floor = 13,
            Apartment = "1304"
        };
        yield return new
        {
            Id = DomDamiraId.ToGuid(),
            City = "Казань",
            Street = "Баева",
            House = "69",
            Section = 5,
            Floor = 3,
            Apartment = "65"
        };
        yield return new
        {
            Id = DomDekoId.ToGuid(),
            City = "Казань",
            Street = "Дениса Жукова",
            House = "1337",
            Section = 55,
            Floor = 55,
            Apartment = "555555"
        };
    }
}