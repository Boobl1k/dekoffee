namespace Main.Application.Models;

public enum OrderStatus
{
    Created,
    Processing,
    InCooking,
    InDelivery,
    Completed,
    Canceled
}

public class Order
{
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime DeadlineTime { get; set; }
    public DateTime CompleteTime { get; set; }
    public DateTime LastUpdateTime { get; set; }
    public OrderStatus Status { get; set; }
    public double TotalSum { get; set; }
    public Address Address { get; set; } = null!;
    public User User { get; set; } = null!;
    public Courier? Courier { get; set; }

    public List<Product> Products { get; set; } = null!;

    public static string GetStatusString(OrderStatus status) =>
        status switch
        {
            OrderStatus.Created => "Создан",
            OrderStatus.Processing => "Обрабатывается",
            OrderStatus.InCooking => "Готовится",
            OrderStatus.InDelivery => "В доставке",
            OrderStatus.Completed => "Завершен",
            OrderStatus.Canceled => "Отменен",
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Invalid Order Status provided")
        };
}