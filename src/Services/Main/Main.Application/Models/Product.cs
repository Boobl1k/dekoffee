namespace Main.Application.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string? Description { get; set; }
    public double Net { get; set; }
    public double Gross { get; set; }
    public string? Country { get; set; }
    public double EnergyValue { get; set; }
    public bool IsBlocked { get; set; }
}