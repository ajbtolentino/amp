using System.Net;
using Newtonsoft.Json;

namespace AMP.Infrastructure.Responses;

public class BaseResponse(HttpStatusCode httpStatusCode, string message)
{
    public HttpStatusCode StatusCode { get; set; } = httpStatusCode;
    public string Message { get; set; } = message;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
