namespace Main.Application.Models;

public class Product
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get; set; }

    /// <summary>
    /// Image URL on Image Storage Server
    /// </summary>
    public string ImageUrl { get; set; } = "https://i.imgur.com/fE10Rf0.jpg";
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public double Net { get; set; }
    public double Gross { get; set; }
    public string Country { get; set; }

    /// <summary>
    /// Energy value per 100 gram
    /// </summary>
    public double EnergyValue { get; set; }

    public bool IsBlocked { get; set; }

#pragma warning disable CS8618
    // ReSharper disable once UnusedMember.Local
    private Product()
#pragma warning restore CS8618
    {
    }

    public Product(string title, string imageUrl, decimal price, string? description, double net, double gross,
        string country, double energyValue)
    {
        Title = title;
        ImageUrl = imageUrl;
        Price = price;
        Description = description;
        Net = net;
        Gross = gross;
        Country = country;
        EnergyValue = energyValue;
    }
}