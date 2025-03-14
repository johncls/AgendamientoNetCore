using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Clients.GetClient
{
    public class ClientResponse
    {
                /// <summary>
        /// Identificacion del cliente
        /// </summary>
        public decimal Identification { get; private set; }
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? Name { get; private set; } = string.Empty;
        /// <summary>
        /// Apellido del cliente
        /// </summary>
        public string? LastName { get; private set; } = string.Empty;
        /// <summary>
        /// Telefono del cliente
        /// </summary>
        public string? Phone { get; private set; }
        /// <summary>
        /// Correo cliente
        /// </summary>
        public string? Email { get; private set; } = string.Empty;
        /// <summary>
        /// dirección
        /// </summary>
        public string Address { get; private set; }  = string.Empty;
        /// <summary>
        /// Ciudad
        /// </summary>
        public string City { get; private set; }  = string.Empty;
        /// <summary>
        /// Departamento
        /// </summary>
        public string State { get; private set;} = string.Empty;
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; private set; }  = string.Empty;
    }
}

