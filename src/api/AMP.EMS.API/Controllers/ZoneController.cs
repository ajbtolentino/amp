using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class ZoneController(IUnitOfWork unitOfWork, ILogger<ZoneController> logger)
    : ApiBaseController<Zone, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ZoneRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Name);

        return await base.Post(new Zone
        {
            EventId = request.EventId,
            Name = request.Name,
            Configuration = request.Configuration ?? string.Empty,
            Capacity = request.Capacity
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ZoneRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Name);

        var zone = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(zone);

        zone.EventId = request.EventId;
        zone.Name = request.Name;
        zone.Configuration = request.Configuration ?? string.Empty;
        zone.Capacity = request.Capacity;

        return await base.Put(zone);
    }

    public record ZoneRequest(
        Guid EventId,
        string Name,
        string? Configuration,
        int Capacity);
}