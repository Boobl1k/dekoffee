using System.ComponentModel.DataAnnotations;
using Main.Application.Models;

namespace Main.Dto.Order;

public class CreateOrderDto
{
    [Required]
    public Guid AddressId { get; set; }
    [Required]
    public DateTime CreationTime { get; set; }
    [Required]
    public DateTime DeadlineTime { get; set; }
    [Required]
    public double TotalSum { get; set; }
    [Required]
    public OrderStatus Status { get; set; }

    public List<Guid> Products { get; set; } = null!;
}