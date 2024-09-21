using AMP.Core.Repository;
using AMP.Infrastructure.Decorators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AMP.Infrastructure.Extensions;

public static class ServiceProviderExtensions
{
    public static IServiceCollection ConfigureUnitOfWork<TUnitOfWork>(this IServiceCollection services)
        where TUnitOfWork : class, IUnitOfWork
    {
        services.AddScoped<TUnitOfWork>();

        return services.AddScoped<IUnitOfWork>(provider =>
        {
            var unitOfWork = provider.GetRequiredService<TUnitOfWork>();
            var logger = provider.GetRequiredService<ILogger<UnitOfWorkDecorator>>();

            return new UnitOfWorkDecorator(unitOfWork, logger);
        });
    }
}
