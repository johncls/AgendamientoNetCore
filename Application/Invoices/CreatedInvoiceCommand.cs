using Application.Abstractions.Messaging;
using Application.DetailInvoices;


namespace Application.Invoices
{
    public record CreatedInvoiceCommand(
        Guid clientId,
        string docClass, 
        int docNumber, 
        string docName, 
        decimal total,
        List<CreatedDetailInvoiceCommand> InvoiceDetails
        ): ICommand<Guid>;
}