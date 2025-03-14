using Domain.Abstractions;

namespace Domain.User.Event
{
    public sealed record UserCreatedDomainEvent (Guid userId) : IDomainEvent;
}