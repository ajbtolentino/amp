using System.Net;

namespace AMP.Infrastructure.Responses;

public class ApiResponse<T>(HttpStatusCode httpStatusCode, string message) : BaseApiResponse(httpStatusCode, message)
{
    public T? Data { get; set; }
}
