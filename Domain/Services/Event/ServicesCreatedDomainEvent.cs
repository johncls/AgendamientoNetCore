using Domain.Abstractions;

namespace Domain.Services.Event
{
     public sealed record ServiceCreatedDomainEvent (Guid serviceId) : IDomainEvent;  
}