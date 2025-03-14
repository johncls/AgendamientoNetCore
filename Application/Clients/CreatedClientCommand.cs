using Application.Abstractions.Messaging;

namespace Application.Clients
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
    public record CreatedClientCommand(
            decimal identification,
            string name,
            string lastName,
            string phone,
            string email,
            string address,
            string city,
            string state,
            string country
        ) : ICommand<Guid>;
}