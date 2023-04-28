using Main.Application.Interfaces;
using Main.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;
    private readonly ILoginService<User> _loginService;
    private readonly IProductService<Product> _productService;

    public CartController(ICartService cartService, ILoginService<User> loginService,
        IProductService<Product> productService)
    {
        _cartService = cartService;
        _loginService = loginService;
        _productService = productService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        if (await _loginService.FindById(id) is not { } user)
            return BadRequest();

        if (await _cartService.GetCartWithProducts(user.Id) is not { } cart)
            return BadRequest();

        return Ok(cart.Products);
    }

    [HttpPost("AddProduct/{id:guid}")]
    public async Task<IActionResult> AddProductToCart(Guid userId, Guid id)
    {
        if (await _loginService.FindById(userId) is not { } user)
            return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequest();

        if (await _cartService.AddProductToCart(user.Id, product) is null)
            throw new Exception("Can't add Product to cart");

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> RemoveProductFromCart(Guid id, int productIndex)
    {
        if (await _loginService.FindById(id) is not { } user)
            return BadRequest();

        await _cartService.RemoveProductFromCart(user.Id, productIndex);
        return Ok();
    }

    [HttpPost("Clear")]
    public async Task<IActionResult> ClearCart(Guid id)
    {
        if (await _loginService.FindById(id) is not { } user)
            return BadRequest();

        await _cartService.ClearCart(user.Id);
        return Ok();
    }
}