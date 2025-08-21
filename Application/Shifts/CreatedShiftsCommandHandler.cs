using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Shifts;

namespace Application.Shifts
{
    public class CreatedShiftsCommandHandler : ICommandHandler<CreatedShiftsCommand, IEnumerable<ShiftsModelResponse>>
    {
        private readonly IShiftsRepository _shiftsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatedShiftsCommandHandler(IShiftsRepository shiftsRepository, IUnitOfWork unitOfWork)
        {
            _shiftsRepository = shiftsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<ShiftsModelResponse>>> Handle(CreatedShiftsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Ejecutar el procedimiento almacenado para generar los turnos
                var shifts = await _shiftsRepository.GenerateShiftsAsync(request.ServiceId, request.StartDate, request.EndDate, cancellationToken);
             
                if (shifts != null && shifts.Any())
                {
                    // Retornar los datos generados por el procedimiento almacenado
                    return Result.Success(shifts);
                }
                else
                {
                    return Result.Failure<IEnumerable<ShiftsModelResponse>>(new Error("Shift.CreationFailed", "No se pudieron generar los turnos"));
                }
                
            }
            catch (Exception ex)
            {
                return Result.Failure<IEnumerable<ShiftsModelResponse>>(new Error("Shift.CreationFailed", ex.Message));
            }
        }
    }
}