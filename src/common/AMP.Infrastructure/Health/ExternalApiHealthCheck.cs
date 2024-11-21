using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AMP.Infrastructure.Health;

public class ExternalApiHealthCheck(string apiUrl) : IHealthCheck
{
    private readonly HttpClient _httpClient = new();

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _httpClient.GetAsync(apiUrl, cancellationToken);

            if (response.IsSuccessStatusCode)
                return HealthCheckResult.Healthy("The external API is reachable.");
            return HealthCheckResult.Degraded(
                $"External API returned a non-success status code: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy($"Error calling the external API: {ex.Message}");
        }
    }
}