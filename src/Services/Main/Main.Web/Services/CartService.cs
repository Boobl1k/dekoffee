using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class CartService : ICartService
{
    private readonly AppDbContext _dbContext;

    public CartService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Cart?> GetCart(Guid id) =>
        await _dbContext.Carts.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Cart?> GetCartWithProducts(Guid id) =>
        await _dbContext.Carts.Include(p => p.Products).FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Cart?> CreateCart(Cart cart)
    {
        _dbContext.Carts.Add(cart);
        await _dbContext.SaveChangesAsync();

        return await GetCart(cart.Id);
    }

    public async Task<Product?> AddProductToCart(Guid id, Product product)
    {
        var cart = await GetCartWithProducts(id) ?? throw new Exception("Not logged in");

        cart.Products.Add(product);
        cart.TotalPrice += product.Price;
        await _dbContext.SaveChangesAsync();

        var lastItem = (await GetCart(cart.Id) ?? throw new Exception("No such cart")).Products
            .LastOrDefault();
        return lastItem == null || lastItem != product ? null : lastItem;
    }

    public async Task RemoveProductFromCart(Guid id, int index)
    {
        var cart = await GetCartWithProducts(id) ?? throw new Exception("Not logged in");
        if (cart.Products.Count <= index)
            throw new ArgumentOutOfRangeException();

        var product = cart.Products[index];
        cart.Products.RemoveAt(index);
        cart.TotalPrice -= product.Price;
        await _dbContext.SaveChangesAsync();
    }

    public async Task ClearCart(Guid id)
    {
        if (await GetCartWithProducts(id) is not { } cart)
            throw new Exception("Not logged in");

        cart.Products.Clear();
        cart.TotalPrice = 0;
        await _dbContext.SaveChangesAsync();
    }
}