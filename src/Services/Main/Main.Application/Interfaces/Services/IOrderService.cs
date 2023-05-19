using System.Linq.Expressions;
using Main.Application.Models;

namespace Main.Application.Interfaces.Services;

public interface IOrderService
{
    Task<Order?> CreateOrder(Order order);
    Task<Order> UpdateOrder(Order order);
    Task DeleteOrder(Order order);
    Task ChangeOrderStatus(Order order, OrderStatus status);
    decimal CalculateOrderTotalSum(IEnumerable<OrderProduct> products);
    IOrderBuilder CreateOrderBuilder();
}

public interface IOrderBuilder
{
    IOrderBuilder WithAddress();
    IOrderBuilder WithUser(Expression<Func<Order, bool>>? expression = null);
    IOrderBuilder WithCourier();
    IOrderBuilder WithOrderProducts();
    IOrderBuilder WithProducts();
    Task<List<Order>> GetOrders();
    Task<Order?> GetOrder(Guid id);
}