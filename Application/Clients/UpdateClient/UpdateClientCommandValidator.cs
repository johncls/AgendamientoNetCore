using FluentValidation;

namespace Application.Clients.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<CreatedClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(c => c.email).NotEmpty();
            RuleFor(c => c.name).NotEmpty();
            RuleFor(c => c.phone).NotEmpty();
            RuleFor(c => c.lastName).NotEmpty();
            RuleFor(c => c.identification).NotEmpty();
        }
    }
}