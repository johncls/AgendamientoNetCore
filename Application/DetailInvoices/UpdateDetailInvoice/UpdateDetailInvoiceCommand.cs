using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.DetailInvoices.UpdateDetailInvoice
{
    public record UpdateDetailInvoiceCommand(
        Guid Id,
        Guid IdInvoice,
        Guid IdProducts,
        decimal Amount,
        decimal PriceUnit,
        decimal SubTotal,
        DateTime DeliveryDate,
        DateTime DeliveryTime,
        bool Deposit
    ) : ICommand<Guid>;

}