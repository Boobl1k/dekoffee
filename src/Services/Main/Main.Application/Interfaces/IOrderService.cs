using Main.Application.Models;

namespace Main.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetOrders();
    Task<Order?> GetOrder(Guid id);
    Task<Order?> CreateOrder(Order order);
    Task DeleteOrder(Order order);
}