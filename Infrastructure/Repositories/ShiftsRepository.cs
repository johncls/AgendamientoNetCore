using System.Data;
using Application.Abstractions.Behaviors.Data;
using Dapper;
using Domain.Shifts;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Repositories
{
    internal sealed class ShiftsRepository : Repository<Shifts>, IShiftsRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        private const string spName = "GenerarTurnos";
        private const int ExtendTimeSeconds = 200;

        public ShiftsRepository(ApplicationDbContext context, ISqlConnectionFactory sqlConnectionFactory) : base(context)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        /// <summary>
        /// Genera los turnos turnos por servicio y rango de fechas
        /// </summary>
        /// <param name="serviceId">ID del servicio</param>
        /// <param name="startDate">Fecha de inicio</param>
        /// <param name="endDate">Fecha de fin</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns>IEnumerable<ShiftsModelResponse> turnos generados</returns>
        /// <exception cref="Exception">Error al generar los turnos</exception>
        public async Task<IEnumerable<ShiftsModelResponse>> GenerateShiftsAsync(Guid serviceId, DateTime startDate, DateTime endDate, CancellationToken cancellationToken = default)
        {
            try
            {

                using var connection = (SqlConnection)_sqlConnectionFactory.CreateConnection();
                await connection.OpenAsync(cancellationToken);

                var parameters = new
                {
                    IdServicio = serviceId,
                    FechaInicio  = startDate.ToString("yyyy-MM-dd"),
                    FechaFin = endDate.ToString("yyyy-MM-dd")
                };

                var result = await connection.QueryAsync<ShiftsModelResponse>(
                    spName,
                    parameters,
                    commandTimeout: ExtendTimeSeconds,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar los turnos", ex);
            }

        }
    }
}