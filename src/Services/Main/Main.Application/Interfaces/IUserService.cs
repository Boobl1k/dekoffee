﻿namespace Main.Application.Interfaces;

public interface IUserService<TEntity> where TEntity : class
{
    Task<bool> ValidateCredentials(string? email, string? password = null, bool checkPassword = false);
    IUserBuilder<TEntity> CreateUserBuilder();
}

public interface IUserBuilder<TEntity> where TEntity : class
{
    IUserBuilder<TEntity> WithAddresses();
    Task<TEntity?> FindByEmail(string? email);
    Task<TEntity?> FindById(Guid id);
    Task<TEntity?> GetCurrentUser();
}