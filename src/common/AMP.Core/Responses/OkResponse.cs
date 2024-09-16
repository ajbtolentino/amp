using System;
using System.Net;

namespace AMP.Core.Responses;

public class OkResponse<T>(HttpStatusCode httpStatusCode, string message) : BaseResponse(httpStatusCode, message)
{
    public T? Data { get; set; }
}
