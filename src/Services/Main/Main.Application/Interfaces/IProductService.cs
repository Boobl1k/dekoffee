namespace Main.Application.Interfaces;

public interface IProductService<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetProducts();
    Task<TEntity?> GetProduct(Guid id);
    Task<TEntity> CreateProduct(TEntity product);
    Task<TEntity> UpdateProduct(TEntity product);
    Task DeleteProduct(TEntity product);
}