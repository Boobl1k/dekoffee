using Main.Application.Models;

namespace Main.Application.Interfaces;

public interface ICartService
{
    Task<Cart?> CreateCart(Cart cart);
    Task<Product?> AddProductToCart(Guid userId, Product product);
    Task RemoveProductFromCart(Guid id, int index);
    Task ClearCart(Guid id);
    ICartBuilder CreateCartBuilder();
}

public interface ICartBuilder
{
    ICartBuilder WithUser();
    ICartBuilder WithProducts();
    Task<Cart?> GetCart(Guid id);
}