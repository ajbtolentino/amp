using System.Net;
using AMP.Core.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AMP.Infrastructure.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        logger.LogError(exception, exception.Message);

        var response = new ErrorResponse((HttpStatusCode)context.Response.StatusCode, exception.Message);

        context.Response.ContentType = context.Response.ContentType;
        context.Response.StatusCode = (int)response.StatusCode;

        await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}
