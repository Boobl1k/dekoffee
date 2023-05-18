using Main.Application.Interfaces.Repositories;
using Main.Application.Models;
using Main.Infrastructure.Data;

namespace Main.Infrastructure.Repositories;

internal class AddressRepository : GenericRepository<Address, AppDbContext>, IAddressRepository
{
    public AddressRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}