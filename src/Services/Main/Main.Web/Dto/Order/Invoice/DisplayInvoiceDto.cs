using System.ComponentModel.DataAnnotations;

namespace Main.Dto.Order.Invoice;

public record DisplayInvoiceDto(
    [Required] Guid OrderId,
    [Required] bool Paid,
    [Required] decimal Sum,
    DateTime? OperationTime
);