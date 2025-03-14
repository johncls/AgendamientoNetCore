using Domain.InvoiceDetail;

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
    }
}