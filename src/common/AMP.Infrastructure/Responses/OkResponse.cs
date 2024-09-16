using System;
using System.Net;

namespace AMP.Infrastructure.Responses;

public class OkResponse<T>(string message) : ApiResponse<T>(HttpStatusCode.OK, message)
{

}
