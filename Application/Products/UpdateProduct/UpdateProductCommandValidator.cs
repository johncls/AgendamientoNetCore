using FluentValidation;

namespace Application.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<CreatedProductCommand>
    {
         public UpdateProductCommandValidator()
         {
            RuleFor(c => c.name).NotEmpty();
            RuleFor(c => c.price).NotEmpty();
         }
    }
}