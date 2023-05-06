using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class ProductService : IProductService<Product>
{
    private readonly AppDbContext _dbContext;

    public ProductService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetProducts() =>
        await _dbContext.Products.ToListAsync();

    public async Task<Product?> GetProduct(Guid id) =>
        await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);

    public async Task<Product?> CreateProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        return await GetProduct(product.Id);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();

        return (await GetProduct(product.Id))!;
    }

    public async Task DeleteProduct(Product product)
    {
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }
}