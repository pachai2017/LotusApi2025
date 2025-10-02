using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LotusApi2025.Infrastructure.DependencyInjection;

/// <summary>
/// Configures MediatR-related services while targeting the supported registration API.
/// </summary>
[ExcludeFromCodeCoverage]
public static class MediatRServiceRegistration
{
    /// <summary>
    /// Registers open-generic request handlers.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <returns>The configured service collection.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> is <c>null</c>.</exception>
    public static IServiceCollection AddApplicationMediatR(this IServiceCollection services)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        // Previously used AddOpenRequestHandlerWithResponse which was removed in MediatR 12.
        services.AddOpenRequestHandler(typeof(LoggingBehavior<,>));

        return services;
    }

    private sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        public Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            return next();
        }
    }
}
