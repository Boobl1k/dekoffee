using Main.Dto.Product;

namespace Main.Dto.OrderProduct;

public class DisplayOrderProductDto
{
    public int Count { get; set; }
    public DisplayProductDto Product { get; set; } = null!;

    public static DisplayOrderProductDto FromEntity(Application.Models.OrderProduct entity) => new()
    {
        Count = entity.Count,
        Product = DisplayProductDto.FromEntity(entity.Product)
    };
}