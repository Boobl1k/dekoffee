namespace Main.Application.Models;

public class Cart
{
    public Guid Id { get; set; }
    public double TotalPrice { get; set; }

    public User User { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
}