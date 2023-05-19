using System.ComponentModel.DataAnnotations;
using Main.Dto.OrderProduct;

namespace Main.Dto.Order;

public class CreateOrderDto
{
    [Required]
    public Guid AddressId { get; set; }
    [Required]
    public DateTime LowerSelectedTime { get; set; }
    [Required]
    public DateTime UpperSelectedTime { get; set; }

    public List<CreateOrderProductDto> Products { get; set; } = null!;
}