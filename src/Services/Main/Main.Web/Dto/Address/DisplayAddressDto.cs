namespace Main.Dto.Address;

public class DisplayAddressDto : AddressDto
{
    public Guid Id { get; set; }

    public static DisplayAddressDto FromEntity(Application.Models.Address entity) => new()
    {
        Apartment = entity.Apartment,
        City = entity.City,
        Commentary = entity.Commentary,
        Floor = entity.Floor,
        House = entity.House,
        Id = entity.Id,
        Section = entity.Section,
        Street = entity.Street
    };
}