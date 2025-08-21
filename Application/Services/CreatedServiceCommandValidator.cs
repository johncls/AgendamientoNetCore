using FluentValidation;

namespace Application.Services
{
    public class CreatedServiceCommandValidator : AbstractValidator<CreatedServiceCommand>
    {
        public CreatedServiceCommandValidator()
        {
            RuleFor(c => c.TradeId)
                .NotEmpty()
                .WithMessage("El id del comercio es requerido");
                
            RuleFor(c => c.NameService)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("El nombre del servicio es requerido y no puede exceder 200 caracteres");
                
            RuleFor(c => c.OpeningHour)
                .NotEmpty()
                .WithMessage("La hora de apertura es requerida");
                
            RuleFor(c => c.ClosingHour)
                .NotEmpty()
                .WithMessage("La hora de cierre debe ser posterior a la hora de apertura");
            RuleFor(c => c.Duration)
                .GreaterThan(29)
                .WithMessage("La duración debe ser mayor o igual 30 minutos");    
        }
    }
}