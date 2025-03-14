using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Product
{
    public interface IProductRepository
    {
        /// <summary>
        /// Busca por nombre el producto
        /// </summary>
        /// <param name="name">nombre del producto</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns></returns>
        Task<Product> GetByNameProductAsync(string name, CancellationToken cancellationToken = default);
        /// <summary>
        /// Persiste en la base de datos producto
        /// </summary>
        /// <param name="product">datos del producto</param>
        void Add(Product product);
        /// <summary>
        /// Metodo para actualizar un producto
        /// </summary>
        /// <param name="product"></param>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateProduct(Product product, Guid id, CancellationToken cancellationToken = default);
        /// <summary>
        /// Metodo para actualizar un producto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteProduct(Guid id, CancellationToken cancellationToken = default);
    }
}