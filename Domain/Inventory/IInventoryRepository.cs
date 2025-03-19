using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Inventory
{
    public interface IInventoryRepository
    {
        /// <summary>
        /// Busca por el id datos del inventario
        /// </summary>
        /// <param name="id">identification</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns></returns>
        Task<Inventory> GetByDetailInvoiceAsync(Guid id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Persiste en la base de datos de inventario
        /// </summary>
        /// <param name="inventory">datos del detalle de la factura</param>
        void Add(Inventory inventory);
    }
}