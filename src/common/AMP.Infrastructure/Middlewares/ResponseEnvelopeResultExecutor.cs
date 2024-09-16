using AMP.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AMP.Infrastructure.Middlewares;

public class ResponseEnvelopeResultExecutor(OutputFormatterSelector formatterSelector,
    IHttpResponseStreamWriterFactory writerFactory,
    ILoggerFactory loggerFactory) : ObjectResultExecutor(formatterSelector, writerFactory, loggerFactory)
{
    public override Task ExecuteAsync(ActionContext context, ObjectResult result)
    {
        Logger.LogInformation("Response", context, result);

        var response = new OkResponse<object>(System.Net.HttpStatusCode.OK, string.Empty) { Data = result.Value };

        TypeCode typeCode = Type.GetTypeCode(result.Value.GetType());
        if (typeCode == TypeCode.Object)
            result.Value = response;

        return base.ExecuteAsync(context, result);
    }
}
