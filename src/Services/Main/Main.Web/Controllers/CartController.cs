using System.Net.Mime;
using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Main.Dto;
using Main.Dto.OrderProduct;
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

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DisplayCountedProductDto>))]
    [HttpGet]
    public async Task<IActionResult> GetCart()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return BadRequest();

        if (await _cartService.CreateCartBuilder().WithProducts().GetUserWithCart(user.Id) is not { } userWithCart)
            return NotFound();

        return Ok(userWithCart.Cart.Products.Select(DisplayCountedProductDto.FromEntity));
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [HttpPost("{id:guid}")]
    public async Task<IActionResult> AddProductToCart([FromRoute] Guid id)
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        if (await _productService.GetProduct(id) is not { } product)
            return NotFound();

        if (await _cartService.AddProductToCart(user.Id, new CartProduct(product)) is null)
            throw new Exception("Cannot add Product");

        return StatusCode(StatusCodes.Status201Created, product.Id);
    }

    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{productIndex:int}")]
    public async Task<IActionResult> RemoveProductFromCart([FromRoute] int productIndex)
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        await _cartService.RemoveProductFromCart(user.Id, productIndex);
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete]
    public async Task<IActionResult> ClearCart()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return UnauthorizedClient();

        await _cartService.ClearCart(user.Id);
        return NoContent();
    }
}