using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AMP.EMS.API.Controllers;

public class InvitationController(IUnitOfWork unitOfWork, ILogger<InvitationController> logger)
    : ApiBaseController<Invitation, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("{id:guid}/guests")]
    public IActionResult GetGuests(Guid id)
    {
        var guestInvitations = UnitOfWork.Set<GuestInvitation>().GetAll()
            .Where(_ => _.InvitationId == id);

        ArgumentNullException.ThrowIfNull(guestInvitations);

        return Ok(new OkResponse<IEnumerable<GuestInvitation>>(string.Empty) { Data = guestInvitations });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] InvitationRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var invitation = new Invitation
            {
                EventId = request.EventId,
                Name = request.Name,
                Description = request.Description ?? string.Empty,
                RsvpDeadline = request.RsvpDeadline
            };

            if (!string.IsNullOrEmpty(request.Html))
                invitation.Content = new Content
                {
                    HtmlContent = request.Html
                };

            await EntityRepository.Add(invitation);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<Invitation>(string.Empty) { Data = invitation });
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
    public async Task<IActionResult> Put(Guid id, [FromBody] InvitationRequest request)
    {
        var invitation = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(invitation);

        try
        {
            UnitOfWork.BeginTransaction();

            invitation.EventId = request.EventId;
            invitation.Name = request.Name;
            invitation.Description = request.Description ?? string.Empty;
            invitation.RsvpDeadline = request.RsvpDeadline;

            if (invitation.ContentId.HasValue)
            {
                var content = await UnitOfWork.Set<Content>().Get(invitation.ContentId.Value);

                content.HtmlContent = request.Html ?? string.Empty;

                UnitOfWork.Set<Content>().Update(content);
            }
            else if (!string.IsNullOrEmpty(request.Html))
            {
                var content = await UnitOfWork.Set<Content>().Add(new Content
                {
                    HtmlContent = request.Html
                });

                invitation.ContentId = content.Id;
            }

            EntityRepository.Update(invitation);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<Invitation>(string.Empty) { Data = invitation });
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransactionAsync();
            logger.LogError(e.Message, e);
            return Problem(e.Message);
        }
    }

    public record InvitationRequest(
        Guid EventId,
        string Name,
        string? Description,
        string? Html,
        DateTime? RsvpDeadline);
}