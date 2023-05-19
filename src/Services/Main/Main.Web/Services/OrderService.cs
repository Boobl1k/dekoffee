using System.Linq.Expressions;
using Main.Application.Interfaces;
using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class OrderService : IOrderService, IOrderBuilder
{
    private readonly IUnitOfWork _unitOfWork;
    private IQueryable<Order> _query;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _query = unitOfWork.Orders.FindAll();
    }

    public async Task<List<Order>> GetOrders() =>
        await _query.ToListAsync();

    public async Task<Order?> GetOrder(Guid id) =>
        await _query.FirstOrDefaultAsync(o => o.Id == id);

    public async Task<Order?> CreateOrder(Order order)
    {
        order.DeadlineTime = order.UpperSelectedTime.AddMinutes(15);
        order.TotalSum = CalculateOrderTotalSum(order.Products);
        _unitOfWork.Orders.Create(order);
        await _unitOfWork.SaveChangesAsync();
        return (await FullOrder(order))!;
    }

    public async Task<Order> UpdateOrder(Order order)
    {
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();
        return (await FullOrder(order))!;
    }

    public async Task DeleteOrder(Order order)
    {
        _unitOfWork.Orders.Delete(order);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ChangeOrderStatus(Order order, OrderStatus status)
    {
        order.Status = status;
        order.LastUpdateTime = DateTime.Now;

        if (order.Status is OrderStatus.Completed or OrderStatus.Canceled)
            order.CompleteTime = order.LastUpdateTime;

        await UpdateOrder(order);
    }

    public decimal CalculateOrderTotalSum(IEnumerable<OrderProduct> products) =>
        products.Sum(p => p.TotalPrice);

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

    public IOrderBuilder WithOrderProducts()
    {
        _query = _query.Include(p => p.Products);
        return this;
    }

    public IOrderBuilder WithProducts()
    {
        _query = _query.Include(p => p.Products).ThenInclude(p => p.Product);
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