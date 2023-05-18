using Main.Application.Interfaces.Repositories;

namespace Main.Application.Interfaces;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IAddressRepository Addresses { get; }
    IInvoiceRepository Invoices { get; }
    IOrderRepository Orders { get; }
    Task SaveChangesAsync();
}