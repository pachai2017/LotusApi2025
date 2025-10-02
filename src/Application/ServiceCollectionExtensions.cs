using System.Reflection;
using LotusFive.Application.Common.Commands;
using LotusFive.Application.Common.Queries;
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

            services.AddTransient(typeof(IRequestHandler<,>), typeof(GetAllEntitiesQueryHandler<>));
            services.AddTransient(typeof(IRequestHandler<,>), typeof(GetEntityByIdQueryHandler<,>));
            services.AddTransient(typeof(IRequestHandler<,>), typeof(CreateEntityCommandHandler<>));
            services.AddTransient(typeof(IRequestHandler<,>), typeof(UpdateEntityCommandHandler<,>));
            services.AddTransient(typeof(IRequestHandler<,>), typeof(DeleteEntityCommandHandler<,>));
            return services;
        }
    }
}
