using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Main.Dto.Product;

public class ProductDto
{
    [Required] public string Title { get; set; } = null!;
    [Required] public string ImageUrl { get; set; } = null!;
    [Required] public decimal Price { get; set; }

    public string? Description { get; set; }

    [Required] public double Net { get; set; }

    [Required] public double Gross { get; set; }

    [Required] public string Country { get; set; } = null!;

    [Required] public double EnergyValue { get; set; }

    [Required] public bool IsBlocked { get; set; }

    [Pure]
    public Application.Models.Product ToEntity()
    {
        return new Application.Models.Product(Title, ImageUrl, Price, Description, Net, Gross, Country, EnergyValue);
    }
}