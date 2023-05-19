using Main.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Main.Infrastructure.Repositories;

internal class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class
    where TContext : DbContext
{
    private readonly TContext _dbContext;

    protected GenericRepository(TContext dbContext) => _dbContext = dbContext;

    public IQueryable<TEntity> FindAll() => _dbContext.Set<TEntity>();

    public void Create(TEntity entity) => _dbContext.Set<TEntity>().Add(entity);
    public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
    public void Delete(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);
}