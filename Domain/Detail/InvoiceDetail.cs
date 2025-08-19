using Domain.Abstractions;
using Domain.InvoiceDetail.Event;
using Domain.Product;

namespace Domain.InvoiceDetail
{
    public class InvoiceDetail : Entity
    {
        public InvoiceDetail()
        {
        }
        public InvoiceDetail(
            Guid id,
            Guid idInvoice,
            Guid idProduct,
            decimal amount,
            decimal priceUnit,
            decimal subTotal,
            DateTime deliveryDate,
            DateTime deliveryTime,
            decimal deposit) : base(id)
        {
            IdInvoice = idInvoice;
            IdProduct = idProduct;
            Amount = amount;
            PriceUnit = priceUnit;
            SubTotal = subTotal;
            DeliveryDate = deliveryDate;
            DeliveryTime = deliveryTime;
            Deposit = deposit;
        }
        /// <summary>
        /// id de la factura 
        /// </summary>
        public Guid IdInvoice { get; set; }
        /// <summary>
        /// id del producto
        /// </summary>
        public Guid IdProduct { get; set; }
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Precio unitario
        /// </summary>
        public decimal PriceUnit { get; set; }
        /// <summary>
        /// sub total de la factura
        /// </summary>
        public decimal SubTotal { get; set; }
        /// <summary>
        /// Fecha de entrega
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// Hora de entrega
        /// </summary>
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// Deposito lata
        /// </summary>
        public decimal Deposit { get; set; }

        public static InvoiceDetail Created(
            Guid idInvoice,
            Guid idProduct,
            decimal amount,
            decimal priceUnit,
            decimal subTotal,
            DateTime deliveryDate,
            DateTime deliveryTime,
            decimal deposit
            )
        {
            subTotal = CalculateSubTotal(amount, priceUnit, deposit);
            var invoiceDetail = new InvoiceDetail(
               Guid.NewGuid(),
               idInvoice,
               idProduct,
               amount,
               priceUnit,
               subTotal,
               deliveryDate,
               deliveryTime,
               deposit);

            invoiceDetail.RaiseDomainEvent(new InvoiceDetailCreatedDomainEvent(invoiceDetail.Id));

            return invoiceDetail;
        }

        public static decimal CalculateSubTotal(decimal amount, decimal priceUnit, decimal deposit)
        {
            return (amount * priceUnit) + deposit;
        }
    }
}