using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal abstract class Repository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _context;
        protected Repository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<T?> GetByPetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public void Add(T Entity)
        {
            _context.Add(Entity);
        }
    }
}