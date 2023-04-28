namespace Main.Application.Interfaces;

public interface IProfileService<TEntity> where TEntity : class
{
    Task<TEntity?> UpdateProfile(TEntity entity);
}