using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class CartService : ICartService, ICartBuilder
{
    private readonly AppDbContext _dbContext;
    private IQueryable<User> _query;

    public CartService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = dbContext.Users.Include(u => u.Cart);
    }

    public async Task<CartProduct?> AddProductToCart(Guid userId, CartProduct product)
    {
        var user = await CreateCartBuilder().WithProducts().GetUserWithCart(userId) ?? throw new Exception("Not logged in");

        user.Cart.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        var lastItem = (await CreateCartBuilder().WithProducts().GetUserWithCart(userId) ?? throw new Exception("No such cart"))
            .Cart
            .Products
            .LastOrDefault();
        return lastItem == null || lastItem != product ? null : lastItem;
    }

    public async Task RemoveProductFromCart(Guid id, int index)
    {
        var user = await CreateCartBuilder().WithProducts().GetUserWithCart(id) ?? throw new Exception("Not logged in");
        if (user.Cart.Products.Count <= index)
            throw new ArgumentOutOfRangeException();

        user.Cart.Products.RemoveAt(index);
        await _dbContext.SaveChangesAsync();
    }

    public async Task ClearCart(Guid id)
    {
        if (await CreateCartBuilder().WithProducts().GetUserWithCart(id) is not { } user)
            throw new Exception("Not logged in");

        user.Cart.Products.Clear();
        await _dbContext.SaveChangesAsync();
    }

    public ICartBuilder CreateCartBuilder() => this;

    public ICartBuilder WithCartProducts()
    {
        _query = _query.Include(c => c.Cart.Products);
        return this;
    }

    public ICartBuilder WithProducts()
    {
        _query = _query.Include(u => u.Cart).ThenInclude(c => c.Products).ThenInclude(p => p.Product);
        return this;
    }

    public async Task<User?> GetUserWithCart(Guid id) =>
        await _query.Where(u => u.Id == id).FirstOrDefaultAsync();
}