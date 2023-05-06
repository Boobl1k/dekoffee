namespace Main.Application.Models;

public class Product
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required double Price { get; set; }
    public required string? Description { get; set; }
    public required double Net { get; set; }
    public required double Gross { get; set; }
    public required string? Country { get; set; }
    public required double EnergyValue { get; set; }
    public required bool IsBlocked { get; set; }
}