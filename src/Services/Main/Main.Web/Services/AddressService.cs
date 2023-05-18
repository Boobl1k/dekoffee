using Main.Application.Interfaces;
using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class AddressService : IAddressService, IAddressBuilder
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IQueryable<Address> _query;

    public AddressService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _query = unitOfWork.Addresses.FindAll();
    }

    public async Task<IEnumerable<Address>> GetAddresses() =>
        await _query.ToListAsync();

    public async Task<Address?> CreateAddress(Address address)
    {
        _unitOfWork.Addresses.Create(address);
        await _unitOfWork.SaveChangesAsync();

        return await GetAddress(address.Id);
    }

    public async Task<Address?> CreateAddressForUser(Address address, User user)
    {
        _unitOfWork.Addresses.Create(address);
        user.Addresses.Add(address);

        await _unitOfWork.SaveChangesAsync();
        return await GetAddress(address.Id);
    }

    public async Task<Address> UpdateAddress(Address address)
    {
        _unitOfWork.Addresses.Update(address);
        await _unitOfWork.SaveChangesAsync();

        return (await GetAddress(address.Id))!;
    }

    public async Task DeleteAddress(Address address)
    {
        _unitOfWork.Addresses.Delete(address);
        await _unitOfWork.SaveChangesAsync();
    }

    public IAddressBuilder CreateAddressBuilder() => this;

    public async Task<Address?> GetAddress(Guid id) =>
        await _query.FirstOrDefaultAsync(a => a.Id == id);
}