
using Application.Abstractions.Messaging;
using Domain.Product;

namespace Application.DetailInvoices
{
    public record CreatedDetailInvoiceCommand(
    Guid Id,
    Guid IdInvoice,
    Guid IdProducts,
    decimal Amount,
    decimal PriceUnit,
    decimal SubTotal,
    DateTime DeliveryDate,
    DateTime DeliveryTime,
    bool Deposit
    ): ICommand<Guid>;

}