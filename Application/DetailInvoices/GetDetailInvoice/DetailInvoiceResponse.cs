using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Products.GetProducts;

namespace Application.DetailInvoices.GetDetailInvoice
{
    public class DetailInvoiceResponse
    {
        /// <summary>
        /// Id del detalle de factura
        /// </summary>
        public Guid IdInvoiceDetail { get; set; }
        /// <summary>
        /// id de la factura 
        /// </summary>
        public Guid IdInvoice { get;  set; }
        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public decimal Amount { get;  set; }
        /// <summary>
        /// Precio unitario
        /// </summary>
        public decimal PriceUnit { get;  set; }
        /// <summary>
        /// sub total de la factura
        /// </summary>
        public decimal SubTotal { get;  set; }
        /// <summary>
        /// Fecha de entrega
        /// </summary>
        public DateTime DeliveryDate { get;  set; }
        /// <summary>
        /// Hora de entrega
        /// </summary>
        public DateTime DeliveryTime { get; set; }
        /// <summary>
        /// Deposito lata
        /// </summary>
        public bool Deposit { get;  set; } = true;
        /// <summary>
        /// produc Name
        /// </summary>
        public string ProductName { get; set; } = string.Empty;
    }
}