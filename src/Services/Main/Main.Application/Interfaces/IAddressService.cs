using Main.Application.Models;

namespace Main.Application.Interfaces;

public interface IAddressService
{
    Task<IEnumerable<Address>> GetAddresses();
    Task<Address?> CreateAddress(Address address);
    Task<Address> UpdateAddress(Address address);
    Task DeleteAddress(Address address);
    IAddressBuilder CreateAddressBuilder();
}

public interface IAddressBuilder
{
    IAddressBuilder WithUser();
    Task<Address?> GetAddress(Guid id);
}