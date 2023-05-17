namespace Main.Dto.Product;

public class DisplayProductDto : ProductDto
{
    public Guid Id { get; set; }

    public static DisplayProductDto FromEntity(Application.Models.Product entity) => new()
    {
        Country = entity.Country,
        Description = entity.Description,
        EnergyValue = entity.EnergyValue,
        Gross = entity.Gross,
        Id = entity.Id,
        IsBlocked = entity.IsBlocked,
        Net = entity.Net,
        Price = entity.Price,
        Title = entity.Title
    };
}