using Main.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[Owned]
public class Cart
{
    public decimal TotalSum { get; set; }
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

    public Cart(decimal totalSum = 0, List<CartProduct>? products = null)
    {
        TotalSum = totalSum;
        Products = products ?? new List<CartProduct>();
    }
}