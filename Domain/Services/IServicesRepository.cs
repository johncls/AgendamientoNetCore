using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IServiceRepository
    {
        /// <summary>
        /// Busca por nombre el servicio
        /// </summary>
        /// <param name="name">nombre del servicio</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns></returns>
        Task<Service?> GetByNameServiceAsync(string name, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Persiste en la base de datos servicio
        /// </summary>
        /// <param name="service">datos del servicio</param>
        void Add(Service service);
        
        
        /// <summary>
        /// Metodo para eliminar un servicio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteService(Guid id, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Metodo para buscar un servicio por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Service?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Metodo para obtener todos los servicios
        /// </summary>
        /// <returns></returns>
        Task<List<Service>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}