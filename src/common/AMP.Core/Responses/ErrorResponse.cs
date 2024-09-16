using System;
using System.Net;

namespace AMP.Core.Responses;

public class ErrorResponse(HttpStatusCode statusCode, string message) : BaseResponse(statusCode, message)
{
}
