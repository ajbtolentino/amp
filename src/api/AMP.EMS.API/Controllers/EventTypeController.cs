using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class EventTypeController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger)
    : ApiBaseController<EventType, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventTypeData data)
    {
        return await base.Post(new EventType
        {
            Name = data.Name,
            Description = data.Description ?? string.Empty
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventTypeData data)
    {
        var eventType = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventType);

        eventType.Name = data.Name;
        eventType.Description = data.Description ?? string.Empty;

        return await base.Put(eventType);
    }

    public record EventTypeData(string Name, string? Description);
}