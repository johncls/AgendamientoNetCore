using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Invoices.GetInvoice
{
    public class InvoiceClientResponse
    {
         /// <summary>
        /// Identificacion del cliente
        /// </summary>
        public decimal Identification { get; set; }
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? ClientName { get; set; } = string.Empty;
        /// <summary>
        /// Apellido del cliente
        /// </summary>
        public string? LastName { get;  set; } = string.Empty;
        /// <summary>
        /// Telefono del cliente
        /// </summary>
        public string? Phone { get;  set; }
        /// <summary>
        /// Correo cliente
        /// </summary>
        public string? Email { get;  set; } = string.Empty;
        /// <summary>
        /// dirección
        /// </summary>
        public string Address { get;  set; }  = string.Empty;
        /// <summary>
        /// Ciudad
        /// </summary>
        public string City { get;  set; }  = string.Empty;
        /// <summary>
        /// Departamento
        /// </summary>
        public string State { get;  set;} = string.Empty;
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get;  set; }  = string.Empty;
    }
}