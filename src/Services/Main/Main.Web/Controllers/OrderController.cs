using Main.Application.Interfaces;
using Main.Application.Models;
using Main.Dto.Order;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("[controller]"), OpenIdDictAuthorize]
public class OrderController : CustomControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IUserService<User> _userService;
    private readonly IProductService<Product> _productService;

    public OrderController(IOrderService orderService, IUserService<User> userService,
        IProductService<Product> productService)
    {
        _orderService = orderService;
        _userService = userService;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        var orders = await _orderService.CreateOrderBuilder()
            .WithCourier()
            .WithAddress()
            .WithProducts()
            .WithUser(o => o.User.Id == user.Id)
            .GetOrders();

        var list = Mapper.Map<List<Order>, List<DisplayOrderDto>>(orders);
        return Ok(list);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOrder(Guid id)
    {
        if (await _userService.CreateUserBuilder().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        if (await _orderService.CreateOrderBuilder()
                .WithCourier()
                .WithAddress()
                .WithProducts()
                .WithUser(o => o.User.Id == user.Id)
                .GetOrder(id) is not { } order)
            return BadRequestInvalidObject(nameof(Order));

        return Ok(Mapper.Map<DisplayOrderDto>(order));
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        if (orderDto.TotalSum <= 0)
            return BadRequest("Order TotalSum can't be 0 or less than 0.");

        if (orderDto.Products.Count == 0)
            return BadRequest("Order can't have 0 Products.");

        if (user.Addresses.FirstOrDefault(a => a.Id == orderDto.AddressId) is not { } address)
            return BadRequestInvalidObject(nameof(Address));

        var order = Mapper.Map<Order>(orderDto);
        order.LastUpdateTime = order.CreationTime;
        order.User = user;
        order.Address = address;
        order.Products = new List<Product>();

        var allProducts = await _productService.GetProducts();
        foreach (var productId in orderDto.Products)
        {
            if (allProducts.FirstOrDefault(p => p.Id == productId) is not { } product)
                return BadRequestInvalidObject(nameof(Product));

            order.Products.Add(product);
        }

        if (await _orderService.CreateOrder(order) is not { } result)
            return BadRequestInvalidObject(nameof(Order));

        return Ok(Mapper.Map<DisplayOrderDto>(result));
    }

    [HttpPost("Cancel/{id:guid}")]
    public async Task<IActionResult> CancelOrder(Guid id)
    {
        if (await _userService.CreateUserBuilder().WithAddresses().GetCurrentUser() is not { } user)
            return ForbidUnauthorizedClient();

        if (await _orderService.CreateOrderBuilder().WithUser(o => o.User.Id == user.Id).GetOrder(id) is not { } order)
            return BadRequestInvalidObject(nameof(Order));

        order.Status = OrderStatus.Canceled;
        await _orderService.UpdateOrder(order);

        return NoContent();
    }
}