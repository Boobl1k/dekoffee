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
        var cart = await CreateCartBuilder().WithProducts().GetCart(userId) ?? throw new Exception("Not logged in");

        cart.Products.Add(product);
        cart.TotalSum += product.Product.Price * product.Count;
        await _dbContext.SaveChangesAsync();

        var lastItem = (await CreateCartBuilder().WithProducts().GetCart(userId) ?? throw new Exception("No such cart"))
            .Products
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
        cart.TotalSum -= product.TotalPrice;
        await _dbContext.SaveChangesAsync();
    }

    public async Task ClearCart(Guid id)
    {
        if (await CreateCartBuilder().WithProducts().GetCart(id) is not { } cart)
            throw new Exception("Not logged in");

        cart.Products.Clear();
        cart.TotalSum = 0;
        await _dbContext.SaveChangesAsync();
    }

    public ICartBuilder CreateCartBuilder() => this;

    public ICartBuilder WithProducts()
    {
        _query = _query.Include(c => c.Cart.Products);
        return this;
    }

    public async Task<Cart?> GetCart(Guid id) =>
        await _query.Where(u => u.Id == id).Select(u => u.Cart).FirstOrDefaultAsync();
}