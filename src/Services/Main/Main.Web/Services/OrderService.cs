using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _dbContext;

    public OrderService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Order>> GetOrders() =>
        await _dbContext.Orders.ToListAsync();

    public async Task<Order?> GetOrder(Guid id) =>
        await _dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);

    public async Task<Order?> CreateOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
        return await GetOrder(order.Id);
    }

    public async Task<Order?> UpdateOrderStatus(Guid id, OrderStatus status)
    {
        var order = await GetOrder(id);
        if (order is null)
            return null;

        switch (status)
        {
            case OrderStatus.Created:
            case OrderStatus.Processing:
            case OrderStatus.InCooking:
            case OrderStatus.InDelivery:
                break;
            case OrderStatus.Completed:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }

        order.Status = status;

        _dbContext.Orders.Update(order);

        await _dbContext.SaveChangesAsync();
        return await GetOrder(id);
    }

    public async Task DeleteOrder(Order order)
    {
        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync();
    }
}