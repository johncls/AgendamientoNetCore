using Application.Abstractions.Behaviors.Data;
using Domain.Abstractions;
using Domain.Services;
using Domain.Shifts;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database") ?? throw new ArgumentException(nameof(configuration));
            
            service.AddScoped<IServiceRepository, ServiceRepository>();
            service.AddScoped<IShiftsRepository, ShiftsRepository>();

            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            service.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            service.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
            return service;
        }
    }
}