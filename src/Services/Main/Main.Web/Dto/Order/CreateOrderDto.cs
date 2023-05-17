using System.ComponentModel.DataAnnotations;
using Main.Application.Models;
using Main.Dto.OrderProduct;

namespace Main.Dto.Order;

public class CreateOrderDto
{
    [Required]
    public Guid AddressId { get; set; }
    [Required]
    public DateTime CreationTime { get; set; }
    [Required]
    public DateTime LowerSelectedTime { get; set; }
    [Required]
    public DateTime UpperSelectedTime { get; set; }
    [Required]
    public DateTime DeadlineTime { get; set; }
    [Required]
    public decimal TotalSum { get; set; }
    [Required]
    public OrderStatus Status { get; set; }

    public List<CreateOrderProductDto> Products { get; set; } = null!;
}