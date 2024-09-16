using System;
using System.Net;

namespace AMP.Infrastructure.Responses;

public class ErrorResponse(HttpStatusCode statusCode, string message) : BaseResponse(statusCode, message)
{
}
