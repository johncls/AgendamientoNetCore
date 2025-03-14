using FluentValidation;

namespace Application.Invoices
{
    public class CreatedInvoiceCommandValidator : AbstractValidator<CreatedInvoiceCommand>
    {
        public CreatedInvoiceCommandValidator()
        {
            RuleFor(c => c.clientId).NotEmpty();
            RuleFor(c => c.docClass).NotEmpty();
            RuleFor(c => c.docNumber).NotEmpty();
            RuleFor(c => c.docName).NotEmpty();
            RuleFor(c => c.total).NotEmpty();
        }
    }
}