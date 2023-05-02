using System.ComponentModel.DataAnnotations;

namespace Main.Dto.User;

public class LoginUserDto
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}