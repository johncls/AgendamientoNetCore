using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Employees.Event;

namespace Domain.Employees
{
    public class Employee : Entity
    {
        public Employee()
        {
        }
        public Employee(Guid id, Guid userId, string firstName, string lastName, DateTime created_at, DateTime updated_at) : base(id)
        {

        }
        /// <summary>
        /// id del usuario
        /// </summary>
        public Guid UserId { get; set; }
        /// <summary>
        /// Primer nombre empleado
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Apellido
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime Created_at { get; set;}
        /// <summary>
        /// Fecha de actualización
        /// </summary>
        public DateTime Updated_at { get; set;}

        public static Employee Created(Guid id, Guid userId, string firstName, string lastName, DateTime created_at, DateTime updated_at){
            var employee = new Employee(
                Guid.NewGuid(),
                userId,
                firstName,
                lastName,
                created_at,
                updated_at
            );

            employee.RaiseDomainEvent(new EmployeesCreatedDomainEvent(employee.Id));

            return employee;
        }
    }
}