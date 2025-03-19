using Domain.Abstractions;

namespace Domain.Inventory.Event
{
    public sealed record InventoryCreatedDomainEvent (Guid inventoryId) : IDomainEvent; 
}