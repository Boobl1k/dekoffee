﻿namespace Main.Dto.User;

public class DisplayUserDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsDeleted { get; set; }
    public bool IsBlocked { get; set; }

    public static DisplayUserDto FromEntity(Application.Models.User entity) => new()
    {
        Email = entity.Email,
        Id = entity.Id,
        IsBlocked = entity.IsBlocked,
        IsDeleted = entity.IsDeleted,
        UserName = entity.UserName
    };
}