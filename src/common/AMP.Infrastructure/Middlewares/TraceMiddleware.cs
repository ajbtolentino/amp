using System;
using Microsoft.AspNetCore.Http;

namespace AMP.Infrastructure.Middlewares;

public class TraceMiddleware(RequestDelegate next)
{
    //https://www.codeproject.com/Tips/5337613/Use-GUID-as-TraceIdentifier-in-ASP-NET-Core-Web-AP

    public async Task Invoke(HttpContext context)
    {
        context.TraceIdentifier = Guid.NewGuid().ToString();
        string id = context.TraceIdentifier;
        context.Response.Headers["X-Trace-Id"] = id;
        await next(context);
    }
}
