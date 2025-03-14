using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Product;

namespace Domain.InvoiceDetail.Event
{
    public sealed record InvoiceDetailCreatedDomainEvent(Guid InvoiceDetailId) : IDomainEvent
    {
        public Guid InvoiceId => throw new NotImplementedException();

        public DateTime CreatedAt => throw new NotImplementedException();

        public string DocName => throw new NotImplementedException();

        public List<ProductItems> Products => throw new NotImplementedException();
    }
}