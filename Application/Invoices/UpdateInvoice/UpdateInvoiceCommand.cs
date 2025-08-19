using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Application.DetailInvoices.UpdateDetailInvoice;

namespace Application.Invoices.UpdateInvoice
{
    public record UpdateInvoiceCommand(
        Guid id,
        Guid clientId,
        DateTime DataCreated,
        string docClass, 
        int docNumber, 
        string docName, 
        decimal total,
        List<UpdateDetailInvoiceCommand> InvoiceDetails
        ): ICommand<Guid>;
}