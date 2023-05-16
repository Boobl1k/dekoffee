namespace Main.Application.Models;

public class OrderProduct : CountedProduct
{
    // ReSharper disable once UnusedMember.Local
    private OrderProduct()
    {
    }

    public OrderProduct(Product product, int count = 1) : base(product, count)
    {
    }
}