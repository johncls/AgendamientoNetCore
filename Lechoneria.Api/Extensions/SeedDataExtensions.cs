using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Abstractions.Behaviors.Data;
using Bogus;
using Bogus.Extensions.Portugal;
using Dapper;

namespace Lechoneria.Api.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnecionFactory>();
            using var connection = sqlConnectionFactory.CreateConnection();

            var faker = new Faker();

            List<object> client = new();

            for (var i = 0; i < 10; i++)
            {
                client.Add(new
                {
                    Id = Guid.NewGuid(),
                    Identification = decimal.Parse(faker.Random.Replace("1012394076")),
                    Name = faker.Name.FirstName(),
                    LastName = faker.Name.LastName(),
                    Phone = faker.Person.Phone,
                    Address = faker.Address.FullAddress(),
                    Email = faker.Person.Email,
                    City  = faker.Address.City(),
                    State = faker.Address.State(),
                    Country = faker.Address.Country(),
                });
            }
            const string sqlSelect = """
               SELECT * FROM public.clients limit 1            
            """;
            var result = connection.ExecuteScalar<object>(sqlSelect);

            if (result == null)
            {
                const string sql = """
               INSERT INTO public.clients(
            id, identification, name, last_name, phone, email, address, city, state, country) VALUES (@Id, @Identification, @Name, @LastName, @Phone, @Email, @Address, @City, @State, @Country)              
            """;

                connection.Execute(sql, client);
            }
        }
    }
}