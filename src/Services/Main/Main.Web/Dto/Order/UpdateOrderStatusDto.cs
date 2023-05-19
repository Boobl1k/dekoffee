using System.ComponentModel.DataAnnotations;
using Main.Application.Models;

namespace Main.Dto.Order;

public class UpdateOrderStatusDto
{
    [Required, EnumDataType(typeof(OrderStatus))] public string OrderStatus { get; set; } = null!;
}