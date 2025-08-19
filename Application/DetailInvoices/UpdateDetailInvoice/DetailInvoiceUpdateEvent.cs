using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.DetailInvoices.UpdateDetailInvoice
{
    public class DetailInvoiceUpdateEvent : INotification
    {
        public Guid Id { get; }
        public Guid InvoiceId { get; }
        public Guid ProductId { get; }
        public decimal Amount { get; }
        public decimal PriceUnit { get; }
        public decimal SubTotal { get; }
        public DateTime DeliveryDate { get; }
        public DateTime DeliveryTime { get; }
        public decimal Deposit { get; }

        public DetailInvoiceUpdateEvent(
            Guid id,
            Guid invoiceId,
            Guid productId,
            decimal amount,
            decimal priceUnit,
            decimal subTotal,
            DateTime deliveryDate,
            DateTime deliveryTime,
            decimal deposit)
        {   
            Id = id;
            InvoiceId = invoiceId;
            ProductId = productId;
            Amount = amount;
            PriceUnit = priceUnit;
            SubTotal = subTotal;
            DeliveryDate = deliveryDate;
            DeliveryTime = deliveryTime;
            Deposit = deposit;
        }
    }
}