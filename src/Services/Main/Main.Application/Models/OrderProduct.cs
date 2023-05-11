using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[Owned]
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