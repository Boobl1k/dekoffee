using Main.Application.Interfaces.Services;
using Main.Application.Models;
using Main.Dto;
using Main.Dto.Address;
using Main.Dto.Order.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace Main.Controllers;

[ApiController]
[Route("orders/{orderId:guid}/invoice")]
[OpenIdDictAuthorize]
public class InvoicesController : CustomControllerBase
{
    private readonly IOrderService _orderService;

    public InvoicesController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("confirm-payment")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayAddressDto))]
    public async Task<IActionResult> CreateInvoice([FromRoute] Guid orderId)
    {
        var order = await _orderService.CreateOrderBuilder().GetOrder(orderId);
        if (order is null) return NotFound();
        if (order.Invoice is { }) return BadRequest("Invoice already paid");
        var invoice = new Invoice(DateTime.Now, order.TotalSum);
        order.Invoice = invoice;
        await _orderService.ChangeOrderStatus(order, OrderStatus.Accepted);
        return Ok(new DisplayInvoiceDto(orderId, true, invoice.Sum, invoice.OperationTime));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ModelStateDto))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayInvoiceDto))]
    public async Task<IActionResult> GetInvoice([FromRoute] Guid orderId)
    {
        var order = await _orderService.CreateOrderBuilder().GetOrder(orderId);
        if (order is null) return NotFound();
        var dto = order.Invoice is { }
            ? new DisplayInvoiceDto(orderId, true, order.Invoice.Sum, order.Invoice.OperationTime)
            : new DisplayInvoiceDto(orderId, false, order.TotalSum, null);
        return Ok(dto);
    }
}