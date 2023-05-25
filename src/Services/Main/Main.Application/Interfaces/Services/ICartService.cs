using Main.Application.Models;

namespace Main.Application.Interfaces.Services;

public interface ICartService
{
    Task<CartProduct?> AddProductToCart(Guid userId, CartProduct product);
    Task RemoveProductFromCart(Guid id, Guid productId);
    Task ClearCart(Guid id);
    ICartBuilder CreateCartBuilder();
}

public interface ICartBuilder
{
    ICartBuilder WithCartProducts();
    ICartBuilder WithProducts();
    Task<User?> GetUserWithCart(Guid id);
}