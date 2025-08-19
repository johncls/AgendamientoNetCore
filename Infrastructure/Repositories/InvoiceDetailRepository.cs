using Domain.InvoiceDetail;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public Task<InvoiceDetail> GetByDetailInvoiceAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateClientAsync(InvoiceDetail invoiceDetail, Guid id, CancellationToken cancellationToken = default)
        {
            try
            {

                var result = _context.InvoicesDetail.FirstOrDefaultAsync(c => invoiceDetail.Id == id, cancellationToken);

                if (result == null)
                    return false;

                _context.ChangeTracker.Clear();
                
                _context.InvoicesDetail.Update(invoiceDetail);

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}