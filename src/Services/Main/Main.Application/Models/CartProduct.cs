using Microsoft.EntityFrameworkCore;

namespace Main.Application.Models;

[Owned]
public class CartProduct : CountedProduct
{
    // ReSharper disable once UnusedMember.Local
    private CartProduct()
    {
    }

    public CartProduct(Product product, int count = 1) : base(product, count)
    {
    }
}