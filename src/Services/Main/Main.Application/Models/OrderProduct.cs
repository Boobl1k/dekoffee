using Main.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[PrimaryKey(nameof(Id))]
public class OrderProduct
{
    public Guid Id { get; } = Guid.NewGuid();
    private readonly Product? _product;
    public Product Product
    {
        get => _product ?? throw new UninitializedException();
        private init => _product = value;
    }
    public int Count { get; set; }
    public decimal TotalPrice => Product.Price * Count;

    // ReSharper disable once UnusedMember.Local
    protected OrderProduct()
    {
    }

    public OrderProduct(Product product, int count = 1)
    {
        Product = product;
        Count = count;
    }
}