namespace Main.Application.Interfaces.Services;

public interface IUserService<TEntity> where TEntity : class
{
    Task<bool> ValidateCredentials(string email, string? password = null, bool checkPassword = false);
    Task<TEntity> UpdateUser(TEntity entity);
    Task BlockUnblockUser(TEntity entity, bool isBlocked);
    Task MarkUserAsDeleted(TEntity entity);
    IUserBuilder<TEntity> CreateUserBuilder();
}

public interface IUserBuilder<TEntity> where TEntity : class
{
    IUserBuilder<TEntity> WithAddresses();
    Task<List<TEntity>> GetUsers();
    Task<TEntity?> FindByEmail(string email);
    Task<TEntity?> FindById(Guid id);
    Task<TEntity?> GetCurrentUser();
}