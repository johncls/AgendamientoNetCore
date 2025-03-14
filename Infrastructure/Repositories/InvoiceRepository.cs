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
                return null;
            }  
            return result;
        }
    }
}