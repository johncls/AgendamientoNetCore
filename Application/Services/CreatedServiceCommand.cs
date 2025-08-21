using Application.Abstractions.Messaging;

namespace Application.Services
{
    /// <summary>
    /// Creación de servicio
    /// </summary>
    /// <param name="NameService">nombre del servicio</param>
    /// <param name="OpeningHour">hora de apertura</param>
    /// <param name="ClosingHour">hora de cierre</param>
    /// <param name="Duration">duración en minutos</param>
    public record CreatedServiceCommand(
            Guid TradeId,
            string NameService,
            TimeSpan OpeningHour,
            TimeSpan ClosingHour,
            int Duration = 30
        ) : ICommand<Guid>;
}