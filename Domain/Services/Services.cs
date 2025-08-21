
using Domain.Abstractions;
using Domain.Services.Event;

namespace Domain.Services
{
    public class Service : Entity
    {
        public Service()
        {
        }
        public Service(
            Guid id,
            Guid tradeId,
            string nameService,
            TimeSpan openingHour,
            TimeSpan closingHour,
            int duration) : base(id)
        {
            TradeId = tradeId;
            NameService = nameService;
            OpeningHour = openingHour;
            ClosingHour = closingHour;
            Duration = duration;
        }
        /// <summary>
        /// Id del comercio
        /// </summary>
        public Guid TradeId { get; set; }
        /// <summary>
        /// Nombre del servicio
        /// </summary>
        public string NameService { get; set; } = string.Empty;
        
        /// <summary>
        /// Hora de apertura del servicio
        /// </summary>
        public TimeSpan OpeningHour { get; set; }
        
        /// <summary>
        /// Hora de cierre del servicio
        /// </summary>
        public TimeSpan ClosingHour { get; set; }
        
        /// <summary>
        /// Duración del servicio en minutos
        /// </summary>
        public int Duration { get; set; }

        public static Service Created(Guid tradeId, string nameService, TimeSpan openingHour, TimeSpan closingHour, int duration)
        {
            var service = new Service(Guid.NewGuid(), tradeId, nameService, openingHour, closingHour, duration);
            service.RaiseDomainEvent(new ServiceCreatedDomainEvent(service.Id));
            return service;
        }
    }
}