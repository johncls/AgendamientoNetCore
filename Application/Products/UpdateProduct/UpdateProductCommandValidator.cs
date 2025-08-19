using FluentValidation;

namespace Application.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdatedProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.CodeProduct).NotEmpty();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.UnitOfMeasurement)
                .MaximumLength(10)
                .When(c => c.UnitOfMeasurement != null);
            RuleFor(c => c.Amount)
                .GreaterThanOrEqualTo(0)
                .When(c => c.Amount.HasValue);
            RuleFor(c => c.DataCreated).NotEmpty();
         }
    }
}