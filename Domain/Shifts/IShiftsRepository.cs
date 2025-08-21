using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Shifts
{
    public interface IShiftsRepository
    {
        // <summary>
        /// Genera los turnos turnos por servicio y rango de fechas
        /// </summary>
        /// <param name="serviceId">ID del servicio</param>
        /// <param name="startDate">Fecha de inicio</param>
        /// <param name="endDate">Fecha de fin</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns></returns>
        Task<IEnumerable<ShiftsModelResponse>> GenerateShiftsAsync(Guid serviceId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default);
        
    }
}