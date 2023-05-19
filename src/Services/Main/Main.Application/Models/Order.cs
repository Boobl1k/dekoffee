using System.Diagnostics.Contracts;
using Main.Application.Exceptions;

namespace Main.Application.Models;

public enum OrderStatus
{
    Created,
    Accepted,
    Cooking,
    Packed,
    InDelivery,
    Completed,
    Canceled
}

public class Order
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime CreationTime { get; } = DateTime.Now;
    public DateTime DeadlineTime { get; set; }
    public DateTime LowerSelectedTime { get; set; }
    public DateTime UpperSelectedTime { get; set; }
    public DateTime? CompleteTime { get; set; }
    public DateTime LastUpdateTime { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Created;
    public decimal TotalSum { get; set; }
    private Address? _address;

    public Address Address
    {
        get => _address ?? throw new UninitializedException();
        set => _address = value;
    }

    private User? _user;

    public User User
    {
        get => _user ?? throw new UninitializedException();
        set => _user = value;
    }

    public User? Executor { get; set; }
    public Invoice? Invoice { get; set; }

    private List<OrderProduct>? _products;

    public List<OrderProduct> Products
    {
        get => _products ?? throw new UninitializedException();
        set => _products = value;
    }

    // ReSharper disable once UnusedMember.Local
    private Order()
    {
    }

    public Order(DateTime lowerSelectedTime, DateTime upperSelectedTime, Address address, User user,
        List<OrderProduct> products)
    {
        LowerSelectedTime = lowerSelectedTime;
        UpperSelectedTime = upperSelectedTime;
        Address = address;
        User = user;
        Products = products;

        LastUpdateTime = CreationTime;
    }

    public static string GetStatusString(OrderStatus status) =>
        status switch
        {
            OrderStatus.Created => "Создан",
            OrderStatus.Accepted => "Принят",
            OrderStatus.Cooking => "Готовится",
            OrderStatus.Packed => "Собран",
            OrderStatus.InDelivery => "В доставке",
            OrderStatus.Completed => "Завершен",
            OrderStatus.Canceled => "Отменен",
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, "Invalid Order Status provided")
        };

    [Pure]
    public IEnumerable<OrderStatus> GetNextStatuses()
    {
        if (Status is OrderStatus.Created)
        {
            yield return OrderStatus.Canceled;
        }

        switch (Status)
        {
            case OrderStatus.Created:
                yield return OrderStatus.Accepted;
                break;
            case OrderStatus.Accepted:
                yield return OrderStatus.Cooking;
                break;
            case OrderStatus.Cooking:
                yield return OrderStatus.Packed;
                break;
            case OrderStatus.Packed:
                yield return OrderStatus.InDelivery;
                break;
            case OrderStatus.InDelivery:
                yield return OrderStatus.Completed;
                break;
            case OrderStatus.Completed:
                break;
            case OrderStatus.Canceled:
            default:
                break;
        }
    }
}