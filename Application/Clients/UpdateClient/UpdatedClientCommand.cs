using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Messaging;
using Domain.Client;

namespace Application.Clients.UpdateClient
{

    /// <summary>
    /// Creacion cliente
    /// </summary>
    /// <param name="identification"> identificación </param>
    /// <param name="name">nombre</param>
    /// <param name="lastName"> apellido</param>
    /// <param name="phone">telefono</param>
    /// <param name="email">correo</param>
    /// <param name="address">direccion</param>
    /// <param name="city">ciudad</param>
    /// <param name="state">departamento</param>
    /// <param name="country">país</param>
    public record UpdatedClientCommand(
            Guid id,
            decimal identification,
            string name,
            string lastName,
            string phone,
            string email,
            string address,
            string city,
            string state,
            string country
        ) : ICommand<Client>;

}