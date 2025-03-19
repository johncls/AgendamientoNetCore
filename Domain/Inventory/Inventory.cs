using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Inventory.Event;

namespace Domain.Inventory
{
    public class Inventory : Entity
    {
        public Inventory()
        {
        }
        public Inventory(
            Guid id,
            Guid idProduct,
            int quantity,
            DateTime lastUpdate
            ) : base(id)
        {
            IdProduct = idProduct;
            Quantity = quantity;
            LastUpdate = lastUpdate;
        }

        public  Guid IdProduct { get;  set; }
        public int Quantity { get;  set; }
        public DateTime LastUpdate { get;  set; }

        public static Inventory Created(
            Guid idProduct,
            int quantity,
            DateTime lastUpdate
            )
        {
            var inventory = new Inventory(
               Guid.NewGuid(),
               idProduct,
               quantity,
               lastUpdate);

            inventory.RaiseDomainEvent(new InventoryCreatedDomainEvent(inventory.Id));

            return inventory;
        }
    }
}