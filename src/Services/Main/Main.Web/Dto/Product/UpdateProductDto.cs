namespace Main.Dto.Product;

public class UpdateProductDto : ProductDto
{
    public void UpdateProduct(Application.Models.Product product)
    {
        product.Title = Title;
        product.Price = Price;
        product.Description = Description;
        product.Net = Net;
        product.Gross = Gross;
        product.Country = Country;
        product.EnergyValue = EnergyValue;
        product.IsBlocked = IsBlocked;
    }
}