using System.ComponentModel;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class ProductRepository : Repository<Product>, IProductRepository
    {
        protected readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<bool> DeleteProduct(Guid id, CancellationToken cancellationToken = default)
        {
           var result = await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (result == null)
                return false;

            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Product> GetByNameProductAsync(string name, CancellationToken cancellationToken = default)
        {
            var result = await _context.Products.FirstOrDefaultAsync(c => c.Name == name,
                                                                cancellationToken);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<bool> UpdateProduct(Product product, Guid id, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingProduct = await _context.Products
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

                if (existingProduct == null)
                    return false;

                _context.Entry(existingProduct).CurrentValues.SetValues(product);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logging framework)
                Console.WriteLine($"Error updating product: {ex.Message}");
                return false;
            }
        }
    }
}