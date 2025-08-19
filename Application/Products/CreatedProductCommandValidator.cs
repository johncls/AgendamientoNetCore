using FluentValidation;

namespace Application.Products
{
    public class CreatedProductCommandValidator : AbstractValidator<CreatedProductCommand>
    {
        public CreatedProductCommandValidator()
        {
            RuleFor(c => c.name).NotEmpty();
            RuleFor(c => c.codeProduct).NotEmpty();
            RuleFor(c => c.price).NotEmpty();
            RuleFor(c => c.UnitOfMeasurement)
                .MaximumLength(10)
                .When(c => c.UnitOfMeasurement != null);
            RuleFor(c => c.Amount).NotEmpty();
            RuleFor(c => c.dateCreated).NotEmpty();
        }
    }
}