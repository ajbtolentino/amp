using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AMP.Infrastructure.Middlewares;

/// <summary>
/// response wrapper
/// </summary>
/// <param name="next"></param>
/// <param name="logger"></param>
public class ResponseHandlingMiddleware(RequestDelegate next, ILogger<ResponseHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        await next.Invoke(context);

        var body = await FormatResponse(context.Response);
        dynamic bodyContent = JsonConvert.DeserializeObject<dynamic>(body);

        logger.LogInformation(nameof(ResponseHandlingMiddleware), context);
    }

    private async Task<string> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var plainBodyText = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return plainBodyText;
    }
}
