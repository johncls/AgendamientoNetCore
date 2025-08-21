using Application.Abstractions.Messaging;
using Domain.Shifts;

namespace Application.Shifts
{
    public record CreatedShiftsCommand(
        Guid ServiceId,
        DateTime StartDate,
        DateTime EndDate
    ) : ICommand<IEnumerable<ShiftsModelResponse>>;
}