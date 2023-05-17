using System.Net.Mime;
using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto;
using Main.Dto.Order;
using Main.Dto.Product;
using Main.Dto.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Main.Controllers;

[ApiController]
[Route("[controller]"), OpenIdDictAuthorize]
public class AdminController : CustomControllerBase
{
    private readonly IProductService<Product> _productService;
    private readonly IUserService<User> _userService;
    private readonly IOrderService _orderService;

    public AdminController(IProductService<Product> productService, IUserService<User> userService,
        IOrderService orderService)
    {
        _productService = productService;
        _userService = userService;
        _orderService = orderService;
    }

    #region Users

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DisplayUserDto>))]
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.CreateUserBuilder().GetUsers();
        return Ok(users.Select(DisplayUserDto.FromEntity));
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayUserDto))]
    [HttpGet("users/{id:guid}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        if (await _userService.CreateUserBuilder().FindById(id) is not { } user)
            return NotFound();
        return Ok(DisplayUserDto.FromEntity(user));
    }

    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("users/{id:guid}")]
    public async Task<IActionResult> BlockUnblockUser([FromRoute] Guid id,
        [FromBody] BlockUnblockUserDto userDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (await _userService.CreateUserBuilder().FindById(id) is not { } user)
            return NotFound();

        user.IsBlocked = userDto.IsBlocked;

        await _userService.UpdateUser(user);
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("users/{id:guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        if (await _userService.CreateUserBuilder().FindById(id) is not { } user)
            return NotFound();
        user.IsDeleted = true;

        await _userService.UpdateUser(user);
        return NoContent();
    }

    #endregion

    #region Products

    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
    [HttpPost("products")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var product = productDto.ToEntity();

        if (await _productService.CreateProduct(product) is not { } result)
            throw new Exception("Cannot create Product");

        return StatusCode(StatusCodes.Status201Created, result.Id);
    }

    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPut("products/{id:guid}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return NotFound();

        productDto.UpdateProduct(product);
        await _productService.UpdateProduct(product);
        return NoContent();
    }

    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("products/{id:guid}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        if (await _productService.GetProduct(id) is not { } product)
            return NotFound();

        await _productService.DeleteProduct(product);
        return NoContent();
    }

    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("products/{id:guid}")]
    public async Task<IActionResult> BlockUnblockProduct([FromRoute] Guid id,
        [FromBody] BlockUnblockProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return NotFound();

        product.IsBlocked = productDto.IsBlocked;

        await _productService.UpdateProduct(product);
        return NoContent();
    }

    #endregion


    #region Orders

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(List<DisplayOrderDto>))]
    [HttpGet("orders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderService.CreateOrderBuilder()
            .WithCourier()
            .WithAddress()
            .WithProducts()
            .WithUser()
            .GetOrders();

        return Ok(orders.Select(DisplayOrderDto.FromEntity));
    }

    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DisplayOrderDto))]
    [HttpGet("orders/{id:guid}")]
    public async Task<IActionResult> GetOrder([FromRoute] Guid id)
    {
        if (await _orderService.CreateOrderBuilder()
                .WithCourier()
                .WithAddress()
                .WithOrderProducts()
                .WithProducts()
                .WithUser()
                .GetOrder(id) is not { } order)
            return NotFound();

        return Ok(DisplayOrderDto.FromEntity(order));
    }

    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpPatch("orders/{id:guid}")]
    public async Task<IActionResult> ChangeOrderStatus([FromRoute] Guid id, [FromBody] UpdateOrderStatusDto orderDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _orderService.CreateOrderBuilder()
                .WithAddress()
                .WithCourier()
                .WithUser()
                .WithProducts()
                .GetOrder(id) is not { } order)
            return NotFound();

        var nextStatus = Enum.Parse<OrderStatus>(orderDto.OrderStatus);
        var possibleStatuses = order.GetNextStatuses().ToArray();
        if (!possibleStatuses.Contains(nextStatus))
            return BadRequest($"Next order status can be: {string.Join(", ", possibleStatuses)}");
        order.Status = nextStatus;
        order.LastUpdateTime = DateTime.Now;

        await _orderService.UpdateOrder(order);

        return NoContent();
    }

    #endregion
}