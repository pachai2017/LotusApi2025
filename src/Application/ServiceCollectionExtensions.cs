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
                cfg.AddOpenRequestHandlerWithResponse(typeof(GetAllEntitiesQuery<>), typeof(GetAllEntitiesQueryHandler<>));
                cfg.AddOpenRequestHandlerWithResponse(typeof(GetEntityByIdQuery<,>), typeof(GetEntityByIdQueryHandler<,>));
                cfg.AddOpenRequestHandlerWithResponse(typeof(CreateEntityCommand<>), typeof(CreateEntityCommandHandler<>));
                cfg.AddOpenRequestHandlerWithResponse(typeof(UpdateEntityCommand<,>), typeof(UpdateEntityCommandHandler<,>));
                cfg.AddOpenRequestHandlerWithResponse(typeof(DeleteEntityCommand<,>), typeof(DeleteEntityCommandHandler<,>));
            });
            return services;
        }
    }
}
