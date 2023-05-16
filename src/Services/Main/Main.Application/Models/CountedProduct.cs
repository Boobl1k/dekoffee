using Main.Application.Exceptions;

namespace Main.Application.Models;

public abstract class CountedProduct
{
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