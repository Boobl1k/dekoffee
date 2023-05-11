using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[PrimaryKey(nameof(Id))]
public class Address
{
    public Guid Id { get; } = Guid.NewGuid();
    public string City { get; set; }
    public string Street { get; set; }
    public string House { get; set; }
    public int? Section { get; set; }
    public int? Floor { get; set; }
    public string? Apartment { get; set; }
    public string? Commentary { get; set; }

#pragma warning disable CS8618
    // ReSharper disable once UnusedMember.Local
    private Address()
#pragma warning restore CS8618
    {
    }

    public Address(string city, string street, string house)
    {
        City = city;
        Street = street;
        House = house;
    }

    public Address(string city, string street, string house, int section, int floor, string apartment) : this(city,
        street, house)
    {
        Section = section;
        Floor = floor;
        Apartment = apartment;
    }

    public override string ToString() =>
        $"г. {City}, ул. {Street} д. {House}" +
        (Section is not null ? $", п. ${Section}, эт. {Floor}, кв. {Apartment}" : null);
}