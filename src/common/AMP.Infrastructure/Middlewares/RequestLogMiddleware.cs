using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AMP.Infrastructure.Middlewares;

public class RequestLogMiddleware(RequestDelegate next, ILogger<RequestLogMiddleware> logger)
{
    private readonly ILogger<RequestLogMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, ILogger<RequestLogMiddleware> logger)
    {
        _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

        await next(context);

        _logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
    }
}
