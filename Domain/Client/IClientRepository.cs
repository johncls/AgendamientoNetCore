using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Client
{
    public interface IClientRepository
    {
        /// <summary>
        /// Busca por la identificacion del cliente
        /// </summary>
        /// <param name="identification">identification</param>
        /// <param name="cancellationToken">cancellacion del token cuando se hace la transacción</param>
        /// <returns></returns>
        Task<Client> GetByClientAsync(decimal identification, CancellationToken cancellationToken = default);
        /// <summary>
        /// Persiste en la base de datos cliente
        /// </summary>
        /// <param name="client">datos del cliente</param>
        void Add(Client client);
        /// <summary>
        /// Metodo en la actualización del cliente
        /// </summary>
        /// <param name="client"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> UpdateClientAsync(Client client, Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Metodo para eliminar el cliente 
        /// </summary>
        /// <param name="id"> id del usuario a eliminar</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteClientAsync(Guid id , CancellationToken cancellationToken = default);
    }
}