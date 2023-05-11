﻿using Main.Application.Models;

namespace Main.Application.Interfaces;

public interface ICartService
{
    Task<CartProduct?> AddProductToCart(Guid userId, CartProduct product);
    Task RemoveProductFromCart(Guid id, int index);
    Task ClearCart(Guid id);
    ICartBuilder CreateCartBuilder();
}

public interface ICartBuilder
{
    ICartBuilder WithProducts();
    Task<Cart?> GetCart(Guid id);
}