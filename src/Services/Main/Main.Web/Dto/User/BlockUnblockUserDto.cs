using System.ComponentModel.DataAnnotations;

namespace Main.Dto.User;

public class BlockUnblockUserDto
{
    [Required] public bool IsBlocked { get; set; }
}