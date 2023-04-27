using System.ComponentModel.DataAnnotations;

namespace Main.Dto;

public class BlockUnblockProductDto
{
    [Required] public bool IsBlocked { get; set; }
}