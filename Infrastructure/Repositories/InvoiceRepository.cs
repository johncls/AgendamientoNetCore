using Domain.Invoice;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        protected readonly ApplicationDbContext _context;
        public InvoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Invoice?> GetByInvoiceAsync(string docName, CancellationToken cancellationToken = default)
        {
            var result = await  _context.Invoices.FirstOrDefaultAsync(x => x.DocName == docName, cancellationToken);

            if(result == null)
            {
                return null; // Return null explicitly as the method now allows nullable Invoice
            }  
            return result;
        }

        public async Task<Invoice?> UpdateInvoiceAsync(Invoice Invoice, string docName, CancellationToken cancellationToken = default)
        {
            try
            {
                _context.ChangeTracker.Clear();
                
                _context.Invoices.Update(Invoice);

                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync(cancellationToken);

                var result = await _context.Invoices.FirstOrDefaultAsync(c => c.Id == Invoice.Id, cancellationToken);
                
                if (result == null)
                    return null;

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }          
            
        }
    }
}