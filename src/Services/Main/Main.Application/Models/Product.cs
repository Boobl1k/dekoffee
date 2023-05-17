using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[PrimaryKey(nameof(Id))]
public class Product
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public double Net { get; set; }
    public double Gross { get; set; }
    public string Country { get; set; }
    public double EnergyValue { get; set; }
    public bool IsBlocked { get; set; }

#pragma warning disable CS8618
    // ReSharper disable once UnusedMember.Local
    private Product()
#pragma warning restore CS8618
    {
    }

    public Product(string title, decimal price, string? description, double net, double gross, string country,
        double energyValue)
    {
        Title = title;
        Price = price;
        Description = description;
        Net = net;
        Gross = gross;
        Country = country;
        EnergyValue = energyValue;
    }
}