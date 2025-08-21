using Domain.Abstractions;

namespace Domain.Trade
{
    public class Trade : Entity
    {
        
        public Trade() { 
        }
        public Trade(
            Guid id,
            string nameTrade,
            int maximunCapacity
            ) : base(id)
        {
            NameTrade = nameTrade;
            MaximunCapacity = maximunCapacity;
        }

        /// <summary>
        /// Nombre del comercio
        /// </summary>
        public string NameTrade { get;  set; } = string.Empty;
        /// <summary>
        /// Capacidad máxima del comercio
        /// </summary>
        public int MaximunCapacity { get;  set; }

    }
}