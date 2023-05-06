namespace Main.Application.Models;

public class Invoice
{
    public Guid Id { get; set; }
    public double Sum { get; set; }
    public DateTime OperationTime { get; set; }

    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;
}