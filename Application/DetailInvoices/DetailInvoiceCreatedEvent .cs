using MediatR;
using Domain.Product;

namespace Application.DetailInvoices
{
    public class DetailInvoiceCreatedEvent : INotification
    {
        public Guid InvoiceId { get; }
        public Guid ProductId { get; }
        public decimal Amount { get; }
        public decimal PriceUnit { get; }
        public decimal SubTotal { get; }
        public DateTime DeliveryDate { get; }
        public DateTime DeliveryTime { get; }
        public decimal Deposit { get; }

        public DetailInvoiceCreatedEvent(
            Guid invoiceId,
            Guid productId,
            decimal amount,
            decimal priceUnit,
            decimal subTotal,
            DateTime deliveryDate,
            DateTime deliveryTime,
            decimal deposit)
        {
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