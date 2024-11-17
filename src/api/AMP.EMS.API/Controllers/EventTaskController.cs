using AMP.Core.Repository;
using AMP.EMS.API.Core.Constants;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class EventTaskController(IUnitOfWork unitOfWork, ILogger<EventTypeController> logger)
    : ApiBaseController<EventTask, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventTaskRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Description);

        return await base.Post(new EventTask
        {
            EventId = request.EventId,
            Description = request.Description,
            State = request.State,
            DateStarted = request.DateStarted,
            DateCompleted = request.DateCompleted
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventTaskRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Description);

        var eventTask = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventTask);

        eventTask.EventId = request.EventId;
        eventTask.Description = request.Description;
        eventTask.State = request.State;
        eventTask.DateStarted = request.DateStarted;
        eventTask.DateCompleted = request.DateCompleted;

        return await base.Put(eventTask);
    }

    public record EventTaskRequest(
        Guid EventId,
        string Description,
        EventTaskState State,
        DateTime? DateStarted,
        DateTime? DateCompleted);
}