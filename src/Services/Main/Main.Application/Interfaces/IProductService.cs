namespace Main.Application.Interfaces;

public interface IProductService<TEntity> where TEntity : class
{
    Task<List<TEntity>> GetProducts();
    Task<TEntity?> GetProduct(Guid id);
    Task<TEntity?> CreateProduct(TEntity entity);
    Task<TEntity> UpdateProduct(TEntity entity);
    Task DeleteProduct(TEntity entity);
}