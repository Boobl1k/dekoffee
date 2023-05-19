using Main.Application.Interfaces;
using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class ProductService : IProductService<Product>
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<List<Product>> GetProducts() =>
        await _unitOfWork.Products.FindAll().ToListAsync();

    public async Task<Product?> GetProduct(Guid id) =>
        await _unitOfWork.Products.FindAll().FirstOrDefaultAsync(product => product.Id == id);

    public async Task<Product?> CreateProduct(Product product)
    {
        _unitOfWork.Products.Create(product);
        await _unitOfWork.SaveChangesAsync();

        return await GetProduct(product.Id);
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        _unitOfWork.Products.Update(product);
        await _unitOfWork.SaveChangesAsync();

        return (await GetProduct(product.Id))!;
    }

    public async Task DeleteProduct(Product product)
    {
        _unitOfWork.Products.Delete(product);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task BlockUnblockProduct(Product product, bool isBlocked)
    {
        product.IsBlocked = isBlocked;
        await UpdateProduct(product);
    }
}