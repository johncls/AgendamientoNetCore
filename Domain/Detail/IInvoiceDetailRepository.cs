namespace Domain.InvoiceDetail
{
    public interface IInvoiceDetailRepository
    {
        /// <summary>
        /// Busca por el id datos de la factura
        /// </summary>
        /// <param name="id">identification</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns></returns>
        Task<InvoiceDetail> GetByDetailInvoiceAsync(Guid id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Persiste en la base de datos cliente
        /// </summary>
        /// <param name="detailInvoice">datos del detalle de la factura</param>
        void Add(InvoiceDetail detailInvoice);
    }
}