using Domain.Abstractions;
using Domain.Client.Events;

namespace Domain.Client
{
    public class Client : Entity
    {
        
        public Client() { 
        }
        public Client(
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
            ) : base(id)
        {
            Identification = identification;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            City = city;
            State = state;
            Country = country;
        }

        /// <summary>
        /// Identificacion del cliente
        /// </summary>
        public decimal Identification { get;  set; }
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? Name { get;  set; } = string.Empty;
        /// <summary>
        /// Apellido del cliente
        /// </summary>
        public string? LastName { get;  set; } = string.Empty;
        /// <summary>
        /// Telefono del cliente
        /// </summary>
        public string? Phone { get;  set; }
        /// <summary>
        /// Correo cliente
        /// </summary>
        public string? Email { get;  set; } = string.Empty;
        /// <summary>
        /// dirección
        /// </summary>
        public string Address { get;  set; }
        /// <summary>
        /// Ciudad
        /// </summary>
        public string City { get;  set; }
        /// <summary>
        /// Departamento
        /// </summary>
        public string State { get;  set;} = string.Empty;
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get;  set; }

        /// <summary>
        /// Metodo encargado de crear el cliente
        /// </summary>
        /// <param name="identification"> Identificacion del cliente</param>
        /// <param name="name">Nombre del cliente</param>
        /// <param name="lastName">Apellido del cliente</param>
        /// <param name="phone">Telefono cliente</param>
        /// <param name="email">Correo cliente</param>
        /// <returns></returns>
        public static Client Create(
              decimal identification,
              string name,
              string lastName,
              string phone,
              string email,
              string address,
              string city,
              string state,
              string country
        )
        {

            var client = new Client(
                Guid.NewGuid(),
                identification,
                name,
                lastName,
                phone,
                email,
                address,
                city,
                state,
                country
            );

            client.RaiseDomainEvent(new ClientCreatedDomainEvent(client.Id!));

            return client;
        }
    }
}