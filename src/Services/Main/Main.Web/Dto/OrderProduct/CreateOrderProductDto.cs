using System.ComponentModel;

namespace Main.Dto.OrderProduct;

public class CreateOrderProductDto
{
    public Guid ProductId { get; set; }
    [DefaultValue("1")]
    public int Count { get; set; }
}