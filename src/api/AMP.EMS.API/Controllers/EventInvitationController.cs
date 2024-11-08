using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventInvitationController(IUnitOfWork unitOfWork, ILogger<EventInvitationController> logger)
    : ApiBaseController<EventInvitation, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("{id:guid}/guests")]
    public IActionResult GetGuests(Guid id)
    {
        var eventGuestInvitations = UnitOfWork.Set<EventGuestInvitation>().GetAll()
            .Where(_ => _.EventInvitationId == id);

        ArgumentNullException.ThrowIfNull(eventGuestInvitations);

        return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuestInvitations });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventInvitationRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var eventInvitation = new EventInvitation
            {
                EventId = request.EventId,
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                RsvpDeadline = request.RsvpDeadline
            };

            if (!string.IsNullOrEmpty(request.Html))
                eventInvitation.Content = new Content
                {
                    HtmlContent = request.Html
                };

            await EntityRepository.Add(eventInvitation);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventInvitation>(string.Empty) { Data = eventInvitation });
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransactionAsync();
            logger.LogError(e.Message, e);
            return Problem(e.Message);
        }
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventInvitationRequest request)
    {
        var eventInvitation = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(eventInvitation);

        try
        {
            UnitOfWork.BeginTransaction();

            eventInvitation.EventId = request.EventId;
            eventInvitation.Name = request.Name;
            eventInvitation.Description = request.Description ?? string.Empty;
            eventInvitation.RsvpDeadline = request.RsvpDeadline;

            if (eventInvitation.ContentId.HasValue)
            {
                var content = await UnitOfWork.Set<Content>().Get(eventInvitation.ContentId.Value);

                content.HtmlContent = request.Html ?? string.Empty;

                UnitOfWork.Set<Content>().Update(content);
            }
            else if (!string.IsNullOrEmpty(request.Html))
            {
                var content = await UnitOfWork.Set<Content>().Add(new Content
                {
                    HtmlContent = request.Html
                });

                eventInvitation.ContentId = content.Id;
            }

            EntityRepository.Update(eventInvitation);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventInvitation>(string.Empty) { Data = eventInvitation });
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransactionAsync();
            logger.LogError(e.Message, e);
            return Problem(e.Message);
        }
    }

    public record EventInvitationRequest(
        Guid EventId,
        string Name,
        string? Description,
        string? Html,
        DateTime? RsvpDeadline);
}