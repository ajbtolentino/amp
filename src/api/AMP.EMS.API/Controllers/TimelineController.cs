using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class TimelineController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger)
    : ApiBaseController<Timeline, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TimelineRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Name);

        return await base.Post(new Timeline
        {
            EventId = request.EventId,
            Name = request.Name,
            Description = request.Description ?? string.Empty,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] TimelineRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Name);

        var timeline = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(timeline);

        timeline.EventId = request.EventId;
        timeline.Name = request.Name;
        timeline.Description = request.Description ?? string.Empty;
        timeline.StartDate = request.StartDate;
        timeline.EndDate = request.EndDate;

        return await base.Put(timeline);
    }

    public record TimelineRequest(
        Guid EventId,
        string Name,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate);
}