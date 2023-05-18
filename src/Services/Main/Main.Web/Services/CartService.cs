using Main.Application.Interfaces;
using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class CartService : ICartService, ICartBuilder
{
    private readonly IUnitOfWork _unitOfWork;
    private IQueryable<User> _query;
    private readonly AppDbContext _dbContext;

    public CartService(UserManager<User> userManager, IUnitOfWork unitOfWork, AppDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
        _query = userManager.Users.Include(u => u.Cart);
    }

    public async Task<CartProduct?> AddProductToCart(Guid userId, CartProduct product)
    {
        var user = await CreateCartBuilder().WithProducts().GetUserWithCart(userId) ??
                   throw new Exception("Not logged in");

        user.Cart.Products.Add(product);
        _dbContext.Update(user);

        await _unitOfWork.SaveChangesAsync();

        var lastItem = (await CreateCartBuilder().WithProducts().GetUserWithCart(userId) ??
                        throw new Exception("No such cart"))
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
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ClearCart(Guid id)
    {
        if (await CreateCartBuilder().WithProducts().GetUserWithCart(id) is not { } user)
            throw new Exception("Not logged in");

        user.Cart.Products.Clear();
        await _unitOfWork.SaveChangesAsync();
    }

    public ICartBuilder CreateCartBuilder() => this;

    public ICartBuilder WithCartProducts()
    {
        _query = _query.Include(u => u.Cart).ThenInclude(c => c.Products);
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