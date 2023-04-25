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

    public async Task<IEnumerable<Product>> GetProducts() =>
        await _dbContext.Products.ToListAsync();

    public async Task<Product?> GetProduct(Guid id) =>
        await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == id);

    public async Task<Product> CreateProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateProduct(Guid id, Product updatedProduct)
    {
        var product = await GetProduct(id) ?? throw new Exception("No such product");

        product.Title = updatedProduct.Title;
        product.Price = updatedProduct.Price;
        product.Description = updatedProduct.Description;
        product.Net = updatedProduct.Net;
        product.Gross = updatedProduct.Gross;
        product.Country = updatedProduct.Country;
        product.EnergyValue = updatedProduct.EnergyValue;
        product.IsBlocked = updatedProduct.IsBlocked;

        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProduct(Guid id)
    {
        if (await GetProduct(id) is not { } product)
            return;

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task BlockProduct(Guid id)
    {
        await ChangeProductAvailability(id, true);
    }

    public async Task UnblockProduct(Guid id)
    {
        await ChangeProductAvailability(id, false);
    }

    private async Task ChangeProductAvailability(Guid id, bool isBlocked)
    {
        if (await GetProduct(id) is not { } product)
            return;

        product.IsBlocked = isBlocked;
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }
}