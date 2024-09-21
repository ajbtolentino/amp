using System;
using System.Net;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AMP.Infrastructure.Middlewares;

public class RequestPipelineMiddleware(RequestDelegate next, ILogger<RequestPipelineMiddleware> logger)
{
    private readonly ILogger<RequestPipelineMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, ILogger<RequestPipelineMiddleware> logger)
    {
        //https://github.com/nayanbunny/dotnet-webapi-response-wrapper-sample/blob/main/DotNet.ResponseWrapper.Sample.Api/Middleware/ResponseWrapperMiddleware.cs
        try
        {
            _logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);

            // Storing Context Body Response
            var currentBody = context.Response.Body;

            // Using MemoryStream to hold Controller Response
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            // Passing call to Controller
            await next(context);

            // Resetting Context Body Response
            context.Response.Body = currentBody;

            // Setting Memory Stream Position to Beginning
            memoryStream.Seek(0, SeekOrigin.Begin);

            // Read Memory Stream data to the end
            var response = new StreamReader(memoryStream).ReadToEnd();

            _logger.LogInformation("Response: {StatusCode} {Response}", context.Response.StatusCode, response);

            // returing response to caller
            await context.Response.WriteAsync(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message} {InnerException}", ex.Message, ex.InnerException);
        }
    }
}
