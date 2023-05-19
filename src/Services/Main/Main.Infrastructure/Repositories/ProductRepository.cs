using Main.Application.Interfaces.Repositories;
using Main.Application.Models;
using Main.Infrastructure.Data;

namespace Main.Infrastructure.Repositories;

internal class ProductRepository : GenericRepository<Product, AppDbContext>, IProductRepository
{
    public ProductRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}