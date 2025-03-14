using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Invoice
{
    public interface IInvoiceRepository
    {
        /// <summary>
        /// Busca por el id datos de la factura
        /// </summary>
        /// <param name="id">identification</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns></returns>
        Task<Invoice> GetByInvoiceAsync(string docName, CancellationToken cancellationToken = default);
        /// <summary>
        /// Persiste en la base de datos cliente
        /// </summary>
        /// <param name="Invoice">datos del pais</param>
        void Add(Invoice Invoice);
    }
}