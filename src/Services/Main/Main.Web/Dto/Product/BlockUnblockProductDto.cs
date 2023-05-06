using System.ComponentModel.DataAnnotations;

namespace Main.Dto.Product;

public class BlockUnblockProductDto
{
    [Required] public bool IsBlocked { get; set; }
}