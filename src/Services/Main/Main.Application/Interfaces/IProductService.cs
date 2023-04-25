namespace Main.Application.Interfaces;

public interface IProductService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetProducts();
    Task<TEntity?> GetProduct(Guid id);
    Task<TEntity> CreateProduct(TEntity product);
    Task<TEntity> UpdateProduct(Guid id, TEntity product);
    Task DeleteProduct(Guid id);
    Task BlockProduct(Guid id);
    Task UnblockProduct(Guid id);
}