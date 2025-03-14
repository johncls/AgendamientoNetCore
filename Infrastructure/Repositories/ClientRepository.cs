using Domain.Client;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class ClientRepository : Repository<Client>, IClientRepository
    {
        protected readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<Client?> GetByClientAsync(decimal identificacion, CancellationToken cancellationToken = default)
        {
            var result = await _context.Clients.FirstOrDefaultAsync(c => c.Identification == identificacion, cancellationToken);

            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> UpdateClientAsync(Client client, Guid id, CancellationToken cancellationToken = default)
        {

            var result = _context.Clients.FirstOrDefaultAsync(c => client.Id == id, cancellationToken);
            if (result == null)
                return false;

            _context.Clients.Update(client);

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task<bool> DeleteClientAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (result == null)
                return false;

            _context.Clients.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}