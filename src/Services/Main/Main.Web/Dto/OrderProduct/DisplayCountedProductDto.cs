using Main.Dto.Product;

namespace Main.Dto.OrderProduct;

public class DisplayCountedProductDto
{
    public int Count { get; set; }
    public DisplayProductDto Product { get; set; } = null!;

    public static DisplayCountedProductDto FromEntity(Application.Models.CountedProduct entity) => new()
    {
        Count = entity.Count,
        Product = DisplayProductDto.FromEntity(entity.Product)
    };
}