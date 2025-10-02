using System.Reflection;
using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace LotusFive.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
