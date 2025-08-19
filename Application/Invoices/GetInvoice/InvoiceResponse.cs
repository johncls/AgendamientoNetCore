using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Clients.GetClient;
using Application.DetailInvoices.GetDetailInvoice;
using Domain.InvoiceDetail;

namespace Application.Invoices.GetInvoice
{
    public class InvoiceResponse
    {
        /// <summary>
        /// Id de la factura 
        /// </summary>
        public Guid InvoiceId { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Doc class de la factura 
        /// </summary>
        public string DocClass { get; set; } = string.Empty;
        /// <summary>
        /// Consecutivo de la factura
        /// </summary>
        public int DocNumber { get; set; } = 0;
        /// <summary>
        /// Nombre del conscutivo
        /// </summary>
        public string DocName { get; set; } = string.Empty;
        /// <summary>
        /// total de la factura
        /// </summary>
        public decimal Total { get; set; } = 0.0m;
        public decimal Identification { get; set; }
        public string? ClientName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        /// <summary>
        /// Detalle de la factura
        /// </summary>
        public List<DetailInvoiceResponse> invoiceDetails { get; set; } = new();
    }
}