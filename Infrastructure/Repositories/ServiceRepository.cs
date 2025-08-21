using Domain.Abstractions;
using Domain.Services;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Service?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        }

        public async Task<Service?> GetByNameServiceAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.Services.FirstOrDefaultAsync(s => s.NameService == name, cancellationToken);
        }

        public new void Add(Service service)
        {
            _context.Services.Add(service);
        }


        public async Task<bool> DeleteService(Guid id, CancellationToken cancellationToken = default)
        {
            var service = await _context.Services.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            if (service == null)
                return false;

            _context.Services.Remove(service);
            return true;
        }

        public async Task<List<Service>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var services = await _context.Services.ToListAsync(cancellationToken);
            
            return services;
        }
    }
} 