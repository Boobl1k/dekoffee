using System.ComponentModel.DataAnnotations;

namespace Main.Dto;

public class AddProductDto
{
    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public double Price { get; set; }
    
    [Required]
    public string? Description { get; set; }
    
    [Required]
    public double Net { get; set; }
    
    [Required]
    public double Gross { get; set; }
    
    [Required]
    public string? Country { get; set; }
    
    [Required]
    public double EnergyValue { get; set; }
    
    [Required]
    public bool IsBlocked { get; set; }
}