using System.Linq.Expressions;
using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class OrderService : IOrderService, IOrderBuilder
{
    private readonly AppDbContext _dbContext;
    private IQueryable<Order> _query;

    public OrderService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = dbContext.Orders;
    }

    public async Task<List<Order>> GetOrders() =>
        await _query.ToListAsync();

    public async Task<Order?> GetOrder(Guid id) =>
        await _query.FirstOrDefaultAsync(o => o.Id == id);

    public async Task<Order?> CreateOrder(Order order)
    {
        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();
        return (await FullOrder(order))!;
    }

    public async Task<Order> UpdateOrder(Order order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
        return (await FullOrder(order))!;
    }

    public async Task DeleteOrder(Order order)
    {
        _dbContext.Orders.Remove(order);
        await _dbContext.SaveChangesAsync();
    }

    public IOrderBuilder WithAddress()
    {
        _query = _query.Include(p => p.Address);
        return this;
    }

    public IOrderBuilder WithUser(Expression<Func<Order, bool>>? expression = null)
    {
        _query = _query.Include(p => p.User);
        if (expression is not null)
            _query = _query.Where(expression);

        return this;
    }

    public IOrderBuilder WithCourier()
    {
        _query = _query.Include(p => p.Executor);
        return this;
    }

    public IOrderBuilder WithProducts()
    {
        _query = _query.Include(p => p.Products);
        return this;
    }

    public IOrderBuilder CreateOrderBuilder() => this;

    private async Task<Order?> FullOrder(Order order) =>
        await CreateOrderBuilder()
            .WithAddress()
            .WithCourier()
            .WithUser()
            .WithProducts()
            .GetOrder(order.Id);
}