using FluentValidation;

namespace Application.Products
{
    public class CreatedProductCommandValidator : AbstractValidator<CreatedProductCommand>
    {
        public CreatedProductCommandValidator()
        {
            RuleFor(c => c.name).NotEmpty();
            RuleFor(c => c.price).NotEmpty();
        }
    }
}