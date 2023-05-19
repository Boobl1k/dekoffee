using Main.Application.Interfaces;
using Main.Application.Interfaces.Repositories;
using Main.Infrastructure.Data;
using Main.Infrastructure.Repositories;

namespace Main.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private IProductRepository? _productRepository;
    private IAddressRepository? _addressRepository;
    private IInvoiceRepository? _invoiceRepository;
    private IOrderRepository? _orderRepository;

    public UnitOfWork(AppDbContext dbContext) => _dbContext = dbContext;

    public IProductRepository Products => _productRepository ??= new ProductRepository(_dbContext);
    public IAddressRepository Addresses => _addressRepository ??= new AddressRepository(_dbContext);
    public IInvoiceRepository Invoices => _invoiceRepository ??= new InvoiceRepository(_dbContext);
    public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_dbContext);

    public async Task SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}