using Application.Abstractions.Behaviors.Data;
using Domain.Abstractions;
using Domain.Client;
using Domain.Invoice;
using Domain.InvoiceDetail;
using Domain.Product;
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
            service.AddScoped<IClientRepository, ClientRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IInvoiceRepository, InvoiceRepository>();
            service.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();

            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });
            service.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            service.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString));
            return service;
        }
    }
}