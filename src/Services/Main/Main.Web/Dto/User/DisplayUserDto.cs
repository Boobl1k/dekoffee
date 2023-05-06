namespace Main.Dto.User;

public class DisplayUserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public bool IsBlocked { get; set; }
}