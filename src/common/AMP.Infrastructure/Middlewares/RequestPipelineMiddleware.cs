using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace AMP.Infrastructure.Middlewares;

public class RequestPipelineMiddleware(RequestDelegate next, ILogger<RequestPipelineMiddleware> logger)
{
    private readonly ILogger<RequestPipelineMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context, ILogger<RequestPipelineMiddleware> logger)
    {
        //https://github.com/nayanbunny/dotnet-webapi-response-wrapper-sample/blob/main/DotNet.ResponseWrapper.Sample.Api/Middleware/ResponseWrapperMiddleware.cs
        try
        {
            // Using MemoryStream to hold Controller Request
            // using var requestMemoryStream = new MemoryStream();
            // context.Request.Body = requestMemoryStream;

            context.Request.EnableBuffering();

            var request = await new StreamReader(context.Request.Body).ReadToEndAsync();
            _logger.LogInformation("HTTP {Method} {Path} {QueryString} received request \n{Request}",
                context.Request.Method,
                context.Request.Path,
                context.Request.QueryString,
                request);

            context.Request.Body.Position = 0;

            // Storing Context Body Response
            var currentBody = context.Response.Body;

            // Using MemoryStream to hold Controller Response
            using var responseMemoryStream = new MemoryStream();
            context.Response.Body = responseMemoryStream;

            // context.Request.Body.Seek(0, SeekOrigin.Begin);

            // Passing call to Controller
            await next(context);

            if (!context.Response?.ContentType?.Contains("image") == true)
            {
                // Resetting Context Body Response
                context.Response.Body = currentBody;

                // Setting Memory Stream Position to Beginning
                responseMemoryStream.Seek(0, SeekOrigin.Begin);

                // Read Memory Stream data to the end
                var response = await new StreamReader(responseMemoryStream).ReadToEndAsync();

                _logger.LogInformation(
                    "HTTP {Method} {Path} {QueryString} returned with a status {StatusCode} and response {Response}",
                    context.Request.Method,
                    context.Request.Path,
                    context.Request.QueryString,
                    context.Response.StatusCode,
                    response);

                // returing response to caller
                await context.Response.WriteAsync(response);
            }
            else
            {
                await context.Response.BodyWriter.WriteAsync(new byte[] { 1 });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
}