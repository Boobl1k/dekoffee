using Main.Application.Interfaces.Repositories;
using Main.Application.Models;
using Main.Infrastructure.Data;

namespace Main.Infrastructure.Repositories;

internal class OrderRepository : GenericRepository<Order, AppDbContext>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}