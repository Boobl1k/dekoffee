namespace Main.Application.Models;

public class Address
{
    public Guid Id { get; set; }
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string House { get; set; } = null!;
    public string Apartment { get; set; } = null!;
    public string Commentary { get; set; } = null!;

    public User User { get; set; } = null!;
}