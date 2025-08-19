using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;

namespace Application.Invoices.GetInvoice
{
    public sealed record GetInvoiceQuery(
        Guid invoiceId, 
        string? DocName, 
        DateTime? CreatedDate, 
        Guid? ClientId
    ) : IQuery<InvoiceResponse>;
        
}