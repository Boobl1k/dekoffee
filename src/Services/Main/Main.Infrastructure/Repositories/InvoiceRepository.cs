using Main.Application.Interfaces.Repositories;
using Main.Application.Models;
using Main.Infrastructure.Data;

namespace Main.Infrastructure.Repositories;

internal class InvoiceRepository : GenericRepository<Invoice, AppDbContext>, IInvoiceRepository
{
    public InvoiceRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}