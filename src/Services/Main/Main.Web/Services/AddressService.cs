using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Services;

public class AddressService : IAddressService, IAddressBuilder
{
    private readonly AppDbContext _dbContext;
    private readonly IQueryable<Address> _query;

    public AddressService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _query = dbContext.Addresses;
    }

    public async Task<IEnumerable<Address>> GetAddresses() =>
        await _query.ToListAsync();

    public async Task<Address?> CreateAddress(Address address)
    {
        _dbContext.Addresses.Add(address);
        await _dbContext.SaveChangesAsync();

        return await GetAddress(address.Id);
    }

    public async Task<Address?> CreateAddressForUser(Address address, User user)
    {
        _dbContext.Addresses.Add(address);
        user.Addresses.Add(address);

        await _dbContext.SaveChangesAsync();
        return await GetAddress(address.Id);
    }

    public async Task<Address> UpdateAddress(Address address)
    {
        _dbContext.Addresses.Update(address);
        await _dbContext.SaveChangesAsync();

        return (await GetAddress(address.Id))!;
    }

    public async Task DeleteAddress(Address address)
    {
        _dbContext.Addresses.Remove(address);
        await _dbContext.SaveChangesAsync();
    }

    public IAddressBuilder CreateAddressBuilder() => this;

    public async Task<Address?> GetAddress(Guid id) =>
        await _query.FirstOrDefaultAsync(a => a.Id == id);
}