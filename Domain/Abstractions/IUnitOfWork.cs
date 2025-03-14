using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Metodo qu nos ayuda con la persistencia en la base de datos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveChangedAsync(CancellationToken cancellationToken = default);
    }
}