using System;
using Microsoft.AspNetCore.Builder;
using Serilog;

namespace AMP.Infrastructure.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseRequestLogging(this WebApplication application)
    {
        application.UseSerilogRequestLogging();

        return application;
    }
}
