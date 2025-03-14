using Domain.Abstractions;

namespace Domain.Client.Events
{
   public sealed record ClientCreatedDomainEvent(Guid ClientId) : IDomainEvent;
}