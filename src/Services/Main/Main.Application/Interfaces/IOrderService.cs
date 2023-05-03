using System.Linq.Expressions;
using Main.Application.Models;

namespace Main.Application.Interfaces;

public interface IOrderService
{
    Task<Order?> CreateOrder(Order order);
    Task<Order> UpdateOrder(Order order);
    Task DeleteOrder(Order order);
    IOrderBuilder CreateOrderBuilder();
}

public interface IOrderBuilder
{
    IOrderBuilder WithAddress();
    IOrderBuilder WithUser(Expression<Func<Order, bool>>? expression = null);
    IOrderBuilder WithCourier();
    IOrderBuilder WithProducts();
    Task<List<Order>> GetOrders();
    Task<Order?> GetOrder(Guid id);
}