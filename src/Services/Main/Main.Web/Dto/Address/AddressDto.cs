using System.ComponentModel.DataAnnotations;

namespace Main.Dto.Address;

public class AddressDto
{
    [Required] public string City { get; set; } = null!;
    [Required] public string Street { get; set; } = null!;
    [Required] public string House { get; set; } = null!;
    [Required] public string Apartment { get; set; } = null!;
    [Required] public string Commentary { get; set; } = null!;
}