using FluentValidation;

namespace Application.Shifts
{
    public class CreatedShiftsCommandValidator : AbstractValidator<CreatedShiftsCommand>
    {
        public CreatedShiftsCommandValidator()
        {
            RuleFor(c => c.ServiceId)
                .NotEmpty()
                .WithMessage("El ID del servicio es requerido");
                
            RuleFor(c => c.StartDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Today)
                .WithMessage("La fecha del turno debe ser hoy o una fecha futura");
                
            RuleFor(c => c.EndDate)
                .NotEmpty()
                .WithMessage("La hora de inicio es requerida");
                
        }
    }
}