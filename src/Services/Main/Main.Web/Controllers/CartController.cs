using Main.Application.Interfaces;
using Main.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]"), OpenIdDictAuthorize]
public class CartController : CustomControllerBase
{
    private readonly ICartService _cartService;
    private readonly IUserService<User> _userService;
    private readonly IProductService<Product> _productService;

    public CartController(ICartService cartService, IUserService<User> userService,
        IProductService<Product> productService)
    {
        _cartService = cartService;
        _userService = userService;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return BadRequest();

        if (await _cartService.CreateCartBuilder().WithProducts().GetCart(user.Id) is not { } cart)
            return BadRequestInvalidObject(nameof(Cart));

        return Ok(cart.Products);
    }

    [HttpPost("AddProduct/{id:guid}")]
    public async Task<IActionResult> AddProductToCart(Guid id)
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequestInvalidObject(nameof(Product));

        if (await _cartService.AddProductToCart(user.Id, product) is null)
            throw new Exception("Can't add Product to cart");

        return Ok();
    }

    [HttpDelete("{productIndex:int}")]
    public async Task<IActionResult> RemoveProductFromCart(int productIndex)
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        await _cartService.RemoveProductFromCart(user.Id, productIndex);
        return Ok();
    }

    [HttpDelete("Clear")]
    public async Task<IActionResult> ClearCart()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        await _cartService.ClearCart(user.Id);
        return Ok();
    }
}