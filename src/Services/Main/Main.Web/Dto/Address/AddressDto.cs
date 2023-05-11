using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Main.Dto.Address;

public class AddressDto
{
    [Required] public string City { get; set; } = null!;
    [Required] public string Street { get; set; } = null!;
    [Required] public string House { get; set; } = null!;
    public int? Section { get; set; }
    public int? Floor { get; set; }
    public string? Apartment { get; set; }
    public string? Commentary { get; set; }

    [Pure]
    public Application.Models.Address ToEntity()
    {
        var address = Section is not null && Floor is not null && Apartment is not null
            ? new Application.Models.Address(City, Street, House, Section.Value,
                Floor.Value, Apartment)
            : new Application.Models.Address(City, Street, House);
        address.Commentary = Commentary;
        return address;
    }
}