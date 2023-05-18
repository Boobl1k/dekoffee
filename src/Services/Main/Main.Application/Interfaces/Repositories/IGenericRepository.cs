namespace Main.Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> FindAll();
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}