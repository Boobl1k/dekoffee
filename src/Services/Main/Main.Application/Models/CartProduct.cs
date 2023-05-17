namespace Main.Application.Models;

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