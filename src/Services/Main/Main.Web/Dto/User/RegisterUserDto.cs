using System.ComponentModel.DataAnnotations;

namespace Main.Dto.User;

public class RegisterUserDto
{
    [Required]
    public string Username { get; set; } = null!;
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string RepeatPassword { get; set; } = null!;
}