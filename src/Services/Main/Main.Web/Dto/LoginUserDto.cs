using ServiceStack.DataAnnotations;

namespace Main.Dto;

public class LoginUserDto
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}