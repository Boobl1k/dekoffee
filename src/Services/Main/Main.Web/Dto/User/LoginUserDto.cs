using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Main.Dto.User;

public class LoginUserDto
{
    [DefaultValue("password")]
    public string grant_type { get; set; } = null!;

    /// <summary>
    /// equals to email
    /// </summary>
    [Required] public string username { get; set; } = null!;
    [Required] public string password { get; set; } = null!;
}