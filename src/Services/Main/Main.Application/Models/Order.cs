namespace Main.Application.Models;

public enum OrderStatus
{
    Created,
    Processing,
    InCooking,
    InDelivery,
    Completed
}

public class Order
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime DeadlineTime { get; set; }
    public DateTime CompleteTime { get; set; }
    public OrderStatus Status { get; set; }

    public Address Address { get; set; } = null!;
    public User User { get; set; } = null!;
    public Courier Courier { get; set; } = null!;

    public List<Product> Products { get; set; } = null!;
}