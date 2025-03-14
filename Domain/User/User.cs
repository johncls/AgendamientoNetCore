using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.User.Event;

namespace Domain.User
{
    public class User : Entity
    {
        public User()
        {
        }

        public User(
            Guid id,
            string userName,
            string password,
            string email,
            string role,
            DateTime created_at,
             DateTime updated_at
        ) : base(id)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Role = role;
            Created_at = created_at;
            Updated_at = updated_at;
        }
        /// <summary>
        /// nombre del usuario
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// contraseña
        /// </summary>
        public string Password { get; set; } = string.Empty ;
        /// <summary>
        /// Email del empleado
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Rol del empleado
        /// </summary>
        public string Role { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime Created_at { get; set;}
        /// <summary>
        /// Actualizacion 
        /// </summary>
        public DateTime Updated_at { get; set;}

        public static User Created(Guid id, string userName, string password, string email, string role, DateTime created_at, DateTime updated_at){

            var user = new User(
                Guid.NewGuid(),
                userName,
                password,
                email,
                role,
                created_at,
                updated_at
            );

            user.RaiseDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
            
        }
    }
}