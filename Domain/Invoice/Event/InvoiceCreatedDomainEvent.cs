using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Invoice.Event
{
        public sealed record InvoiceCreatedDomainEvent (Guid invoiceId) : IDomainEvent;  
}