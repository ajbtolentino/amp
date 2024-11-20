using AMP.Core.Repository;
using AMP.Infrastructure.Configurations;
using AMP.Infrastructure.Decorators;
using AMP.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

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

    public static IServiceCollection AddDbContext<TDbContext>(this IServiceCollection services,
        IConfigurationManager configurationManager)
        where TDbContext : DbContext
    {
        var dbType =
            configurationManager.GetValue<DatabaseType>(
                $"{nameof(DatabaseConfiguration)}:{nameof(DatabaseConfiguration.Type)}");
        var connectionString = configurationManager.GetConnectionString("DefaultConnection")!;

        switch (dbType)
        {
            case DatabaseType.SqlServer:
                services.AddDbContext<TDbContext>(options =>
                    options.UseSqlServer(connectionString,
                            sqlOptions => sqlOptions.EnableRetryOnFailure(20, TimeSpan.FromSeconds(60), null))
                        .ConfigureWarnings(warnings =>
                            warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));
                break;
            case DatabaseType.Sqlite:
                services.AddDbContext<TDbContext>(options =>
                    options.UseSqlite(connectionString));
                break;
            case DatabaseType.MongoDb:
                BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
                var client = new MongoClient(connectionString);
                services.AddDbContext<TDbContext>(
                    options => options.UseMongoDB(client, client.Settings.ApplicationName));

                break;
        }

        services.AddScoped<DbContext, TDbContext>();

        return services;
    }

    public static void Migrate<TDbContext>(this IServiceProvider serviceProvider,
        IConfigurationManager configurationManager) where TDbContext : DbContext
    {
        var dbType =
            configurationManager.GetValue<DatabaseType>(
                $"{nameof(DatabaseConfiguration)}:{nameof(DatabaseConfiguration.Type)}");

        if (dbType != DatabaseType.MongoDb)
        {
            using var scope = serviceProvider.CreateScope();
            var dataContext = scope.ServiceProvider.GetRequiredService<TDbContext>();

            if (dataContext.Database.GetPendingMigrations().Any())
                dataContext.Database.Migrate();
        }
    }
}