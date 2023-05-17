using Main.Application.Exceptions;

namespace Main.Application.Models;

public class Cart
{
    private List<CartProduct>? _products;

    public List<CartProduct> Products
    {
        get => _products ?? throw new UninitializedException();
        set => _products = value;
    }

    // ReSharper disable once UnusedMember.Local
    private Cart()
    {
    }

    public Cart(List<CartProduct>? products = null)
    {
        Products = products ?? new List<CartProduct>();
    }
}