using Main.Dto.Product;

namespace Main.Dto.Order;

public class DisplayOrderDto
{
    public Guid Id { get; set; }
    public string FullAddress { get; set; } = null!;
    public string? CourierName { get; set; }
    public DateTime CreationTime { get; set; }
    public double TotalSum { get; set; }
    public string Status { get; set; } = null!;

    public List<ProductDto> Products { get; set; } = null!;
}