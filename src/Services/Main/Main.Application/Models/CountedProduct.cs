using Main.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[PrimaryKey(nameof(Id))]
public abstract class CountedProduct
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

    protected CountedProduct()
    {
    }

    public CountedProduct(Product product, int count = 1)
    {
        Product = product;
        Count = count;
    }
}