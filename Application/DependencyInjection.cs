using Application.Abstractions.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Metodo encargado de registrar todos los servicioes y utilizarlos con el patron mediator
        /// </summary>
        /// <param name="services">nombre del servicio</param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                configuration.AddOpenBehavior(typeof(Loggingbehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            //services.AddTransient<Client>();
            //services.AddTransient<Pet>();
            //services.AddTransient<Policy>();
            //services.AddTransient<Price>();
            //services.AddTransient<Pqr>();

            return services;
        }
    }
}