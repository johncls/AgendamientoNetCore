
using Application.Abstractions.Messaging;
using Domain.Product;

namespace Application.DetailInvoices
{
    public record CreatedDetailInvoiceCommand(
    Guid IdProducts,
    decimal Amount,
    decimal PriceUnit,
    decimal SubTotal,
    DateTime DeliveryDate,
    DateTime DeliveryTime,
    decimal Deposit
    ): ICommand<Guid>;

}