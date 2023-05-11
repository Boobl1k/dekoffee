using Main.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[Owned]
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