using System.Net;

namespace AMP.Core.Responses;

public class BaseResponse(HttpStatusCode httpStatusCode, string message)
{
    public HttpStatusCode StatusCode { get; set; } = httpStatusCode;
    public string Message { get; set; } = message;
}
