namespace Main.Dto.Address;

public class UpdateAddressDto : AddressDto
{
    public void UpdateAddress(Application.Models.Address address)
    {
        address.City = City;
        address.Street = Street;
        address.House = House;
        if (Section is not null && Floor is not null && Apartment is not null)
        {
            address.Section = Section;
            address.Floor = Floor;
            address.Apartment = Apartment;
        }

        address.Commentary = Commentary;
    }
}