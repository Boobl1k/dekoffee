using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto.Order;
using Main.Dto.Product;
using Main.Dto.User;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet($"Users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.CreateUserBuilder().GetUsers();
        return Ok(Mapper.Map<List<User>, List<DisplayUserDto>>(users));
    }

    [HttpGet("Users/{id:guid}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        if (await _userService.CreateUserBuilder().FindById(id) is not { } user)
            return BadRequestInvalidObject(nameof(User));
        return Ok(Mapper.Map<DisplayUserDto>(user));
    }

    [HttpPatch("Users/BlockUnblock/{id:guid}")]
    public async Task<IActionResult> BlockUnblockUser([FromRoute] Guid id,
        [FromBody] BlockUnblockUserDto userDto)
    {
        if (!ModelState.IsValid) return BadRequest();
        if (await _userService.CreateUserBuilder().FindById(id) is not { } user)
            return BadRequestInvalidObject(nameof(User));

        user = Mapper.Map(userDto, user);

        var result = await _userService.UpdateUser(user);
        return Ok(Mapper.Map<DisplayUserDto>(result));
    }

    [HttpPatch("Users/Delete/{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        if (await _userService.CreateUserBuilder().FindById(id) is not { } user)
            return BadRequestInvalidObject(nameof(User));
        user.IsDeleted = true;

        var result = await _userService.UpdateUser(user);
        return Ok(Mapper.Map<DisplayUserDto>(result));
    }

    #endregion

    #region Products

    [HttpPost("Products")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var product = Mapper.Map<Product>(productDto);

        if (await _productService.CreateProduct(product) is not { } result)
            throw new Exception("Product is not created");

        return Ok(Mapper.Map<DisplayProductDto>(result));
    }

    [HttpPut("Products/{id:guid}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequestInvalidObject(nameof(Product));

        product = Mapper.Map(productDto, product);
        var result = await _productService.UpdateProduct(product);

        return Ok(Mapper.Map<DisplayProductDto>(result));
    }

    [HttpDelete("Products/{id:guid}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        if (await _productService.GetProduct(id) is not { } product)
            return BadRequestInvalidObject(nameof(Product));

        await _productService.DeleteProduct(product);
        return Ok();
    }

    [HttpPatch("Products/{id:guid}")]
    public async Task<IActionResult> BlockUnblockProduct([FromRoute] Guid id,
        [FromBody] BlockUnblockProductDto productDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _productService.GetProduct(id) is not { } product)
            return BadRequestInvalidObject(nameof(Product));

        product = Mapper.Map(productDto, product);

        var result = await _productService.UpdateProduct(product);
        return Ok(Mapper.Map<DisplayProductDto>(result));
    }

    #endregion


    #region Orders

    [HttpGet("Orders")]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _orderService.CreateOrderBuilder()
            .WithCourier()
            .WithAddress()
            .WithProducts()
            .WithUser()
            .GetOrders();

        var list = Mapper.Map<List<Order>, List<DisplayOrderDto>>(orders);
        return Ok(list);
    }

    [HttpGet("Orders/{id:guid}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        if (await _orderService.CreateOrderBuilder()
                .WithCourier()
                .WithAddress()
                .WithProducts()
                .WithUser()
                .GetOrder(id) is not { } order)
            return BadRequestInvalidObject(nameof(Order));

        return Ok(Mapper.Map<DisplayOrderDto>(order));
    }

    [HttpPatch("Orders/ChangeStatus/{id:guid}")]
    public async Task<IActionResult> ChangeOrderStatus(Guid id, [FromBody] UpdateOrderStatusDto orderDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _orderService.CreateOrderBuilder()
                .WithAddress()
                .WithCourier()
                .WithUser()
                .WithProducts()
                .GetOrder(id) is not { } order)
            return BadRequestInvalidObject(nameof(Order));

        order = Mapper.Map(orderDto, order);
        order.LastUpdateTime = DateTime.Now;

        await _orderService.UpdateOrder(order);

        return Ok();
    }

    #endregion
}