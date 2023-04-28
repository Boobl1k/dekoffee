using Main.Application.Models;

namespace Main.Application.Interfaces;

public interface ICartService
{
    Task<Cart?> GetCart(Guid id);
    Task<Cart?> GetCartWithProducts(Guid id);
    Task<Cart?> CreateCart(Cart cart);
    Task<Product?> AddProductToCart(Guid id, Product product);
    Task RemoveProductFromCart(Guid id, int productIndex);
    Task ClearCart(Guid id);
}