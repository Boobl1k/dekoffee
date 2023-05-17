using Main.Dto.OrderProduct;
using Main.Dto.Product;

namespace Main.Dto.Order;

public class DisplayOrderDto
{
    public Guid Id { get; set; }
    public string FullAddress { get; set; } = null!;
    public string? ExecutorName { get; set; }
    public DateTime CreationTime { get; set; }
    public decimal TotalSum { get; set; }
    public string Status { get; set; } = null!;

    public IEnumerable<DisplayCountedProductDto> Products { get; set; } = null!;

    public static DisplayOrderDto FromEntity(Application.Models.Order entity) => new()
    {
        ExecutorName = entity.Executor?.UserName,
        CreationTime = entity.CreationTime,
        FullAddress = entity.Address.ToString(),
        Id = entity.Id,
        Products = entity.Products.Select(DisplayCountedProductDto.FromEntity),
        Status = Application.Models.Order.GetStatusString(entity.Status),
        TotalSum = entity.TotalSum
    };
}