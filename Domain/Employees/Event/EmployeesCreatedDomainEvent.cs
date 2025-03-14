using Domain.Abstractions;

namespace Domain.Employees.Event
{
    public sealed record EmployeesCreatedDomainEvent (Guid employeedId) : IDomainEvent;
}