namespace Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity() { }
        private readonly List<IDomainEvent> _events = new();
        protected Entity(Guid id)
        {
            Id = id;
        }
        /// <summary>
        /// Id de de las entitades extendidas
        /// </summary>
        public Guid Id { get; init; }
        /// <summary>
        /// Metodo que  llama el evento
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _events.ToList();
        }
        /// <summary>
        /// Metodo encargado de limpiar la lista
        /// </summary>
        public void ClearDomainEvents()
        {
            _events.Clear();
        }
        /// <summary>
        /// Metodo que agrega el evento a la lista
        /// </summary>
        /// <param name="domainEvents"></param>
        protected void RaiseDomainEvent(IDomainEvent domainEvents)
        {
            _events.Add(domainEvents);
        }
    }
}