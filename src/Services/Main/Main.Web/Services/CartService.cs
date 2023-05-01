using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class CartService : ICartService, ICartBuilder
{
    private readonly AppDbContext _dbContext;
    private IQueryable<Cart> _query;

    public CartService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = dbContext.Carts;
    }

    public async Task<Cart?> CreateCart(Cart cart)
    {
        _dbContext.Carts.Add(cart);
        await _dbContext.SaveChangesAsync();

        return await GetCart(cart.Id);
    }

    public async Task<Product?> AddProductToCart(Guid userId, Product product)
    {
        var cart = await CreateCartBuilder().WithProducts().GetCart(userId) ?? throw new Exception("Not logged in");

        cart.Products.Add(product);
        cart.TotalPrice += product.Price;
        await _dbContext.SaveChangesAsync();

        var lastItem = (await GetCart(cart.Id) ?? throw new Exception("No such cart")).Products
            .LastOrDefault();
        return lastItem == null || lastItem != product ? null : lastItem;
    }

    public async Task RemoveProductFromCart(Guid id, int index)
    {
        var cart = await CreateCartBuilder().WithProducts().GetCart(id) ?? throw new Exception("Not logged in");
        if (cart.Products.Count <= index)
            throw new ArgumentOutOfRangeException();

        var product = cart.Products[index];
        cart.Products.RemoveAt(index);
        cart.TotalPrice -= product.Price;
        await _dbContext.SaveChangesAsync();
    }

    public async Task ClearCart(Guid id)
    {
        if (await CreateCartBuilder().WithProducts().GetCart(id) is not { } cart)
            throw new Exception("Not logged in");

        cart.Products.Clear();
        cart.TotalPrice = 0;
        await _dbContext.SaveChangesAsync();
    }

    public ICartBuilder CreateCartBuilder() => this;

    public ICartBuilder WithUser()
    {
        _query = _query.Include(c => c.User);
        return this;
    }

    public ICartBuilder WithProducts()
    {
        _query = _query.Include(c => c.Products);
        return this;
    }

    public async Task<Cart?> GetCart(Guid id) =>
        await _query.FirstOrDefaultAsync(c => c.Id == id);
}