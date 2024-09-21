using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.OpenTelemetry;

namespace AMP.Infrastructure.Extensions;

public static class ConfigureHostBuilderExtensions
{
    public static ConfigureHostBuilder ConfigureLogger(this ConfigureHostBuilder builder)
    {
        builder.UseSerilog((context, configuration) =>
            configuration
            .WriteTo.OpenTelemetry("http://localhost:5341", OtlpProtocol.HttpProtobuf, null, new Dictionary<string, object>
            {
                { "service.name", typeof(ConfigureHostBuilderExtensions).Assembly.GetName().Name ?? "unknown_service" }
            })
            .ReadFrom.Configuration(context.Configuration));

        return builder;
    }
}
