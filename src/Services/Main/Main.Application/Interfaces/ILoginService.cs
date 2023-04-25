namespace Main.Application.Interfaces;

public interface ILoginService<TEntity> where TEntity : class
{
    Task<bool> ValidateCredentials(string? email, string? password = null, bool checkPassword = false);

    Task<TEntity?> FindByEmail(string? email);

    Task<TEntity?> GetCurrentUser();
}