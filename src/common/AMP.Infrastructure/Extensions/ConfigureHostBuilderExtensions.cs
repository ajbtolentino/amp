using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AMP.Infrastructure.Extensions;

public static class ConfigureHostBuilderExtensions
{
    public static ConfigureHostBuilder ConfigureLogger(this ConfigureHostBuilder builder)
    {
        builder.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration));

        return builder;
    }
}
