using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Product.Event
{
     public sealed record ProductCreatedDomainEvent (Guid productId) : IDomainEvent;  
}