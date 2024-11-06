using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Helpers;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventGuestController(IUnitOfWork unitOfWork, ILogger<EventGuestController> logger)
    : ApiBaseController<EventGuest, Guid>(unitOfWork, logger)
{
    public override async Task<IActionResult> Get(Guid id)
    {
        var eventGuest = await EntityRepository.GetAll()
            .Where(_ => _.Id == id)
            .Include(_ => _.Guest)
            .Include(_ => _.EventGuestInvitations)
            .ThenInclude(_ => _.EventInvitation)
            .Include(_ => _.EventGuestInvitations)
            .ThenInclude(_ => _.EventGuestInvitationRsvps)
            .ThenInclude(_ => _.EventGuestInvitationRsvpItems)
            .Include(_ => _.EventGuestRoles)
            .ThenInclude(_ => _.Role)
            .FirstOrDefaultAsync();

        ArgumentNullException.ThrowIfNull(eventGuest);

        return Ok(new OkResponse<EventGuest>(string.Empty) { Data = eventGuest });
    }

    public override IActionResult GetAll()
    {
        var eventGuests = EntityRepository.GetAll()
            .Include(_ => _.Guest)
            .Include(_ => _.EventGuestInvitations)
            .ThenInclude(_ => _.EventInvitation)
            .Include(_ => _.EventGuestInvitations)
            .ThenInclude(_ => _.EventGuestInvitationRsvps)
            .ThenInclude(_ => _.EventGuestInvitationRsvpItems)
            .Include(_ => _.EventGuestRoles)
            .ThenInclude(_ => _.Role);

        ArgumentNullException.ThrowIfNull(eventGuests);

        return Ok(new OkResponse<IEnumerable<EventGuest>>(string.Empty) { Data = eventGuests });
    }

    [HttpGet]
    [Route("{id:guid}/invitations")]
    public IActionResult GetInvitations(Guid id)
    {
        var eventGuestInvitations = UnitOfWork.Set<EventGuestInvitation>().GetAll()
            .Where(_ => _.EventGuestId == id)
            .Include(_ => _.EventInvitation)
            .Include(_ => _.EventGuestInvitationRsvps)
            .ThenInclude(_ => _.EventGuestInvitationRsvpItems);

        ArgumentNullException.ThrowIfNull(eventGuestInvitations);

        return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuestInvitations });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventGuestRequest request)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(request.Guest);

            UnitOfWork.BeginTransaction();

            var newGuest = await UnitOfWork.Set<Guest>().Add(new Guest
            {
                FirstName = request.Guest.FirstName,
                LastName = request.Guest.LastName,
                NickName = request.Guest.Nickname ?? string.Empty,
                PhoneNumber = request.Guest.PhoneNumber ?? string.Empty
            });

            var newEventGuest = await EntityRepository.Add(new EventGuest
            {
                EventId = request.EventId,
                GuestId = newGuest.Id,
                Seats = request.Seats ?? 1
            });

            UpdateEventGuestInvitations(newEventGuest, request.EventInvitationIds ?? []);
            UpdateEventGuestRoles(newEventGuest, request.EventRoleIds ?? []);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventGuest>(string.Empty) { Data = newEventGuest });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }

        return BadRequest();
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestRequest request)
    {
        try
        {
            var eventGuest = await EntityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventGuest);

            UnitOfWork.BeginTransaction();

            var guest = await UnitOfWork.Set<Guest>().Get(eventGuest.GuestId);

            ArgumentNullException.ThrowIfNull(guest);

            guest.FirstName = request.Guest.FirstName;
            guest.LastName = request.Guest.LastName;
            guest.NickName = request.Guest.Nickname ?? string.Empty;
            guest.PhoneNumber = request.Guest.PhoneNumber ?? string.Empty;

            UnitOfWork.Set<Guest>().Update(guest);

            eventGuest.Seats = request.Seats ?? 0;

            UpdateEventGuestInvitations(eventGuest, request.EventInvitationIds ?? []);
            UpdateEventGuestRoles(eventGuest, request.EventRoleIds ?? []);

            EntityRepository.Update(eventGuest);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            eventGuest = await EntityRepository.GetAll()
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();

            return Ok(new OkResponse<EventGuest>(string.Empty) { Data = eventGuest });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    private void UpdateEventGuestInvitations(EventGuest eventGuest, IEnumerable<Guid> eventInvitationIds)
    {
        var eventGuestInvitations = UnitOfWork.Set<EventGuestInvitation>().GetAll().AsNoTracking()
            .Where(_ => _.EventGuestId == eventGuest.Id);
        var newEventInvitationIds =
            eventInvitationIds.Except(eventGuestInvitations.Select(_ => _.EventInvitationId));
        var deletedEventGuestInvitations =
            eventGuestInvitations.Where(_ => !eventInvitationIds.Contains(_.EventInvitationId));

        foreach (var eventInvitationId in newEventInvitationIds)
            UnitOfWork.Set<EventGuestInvitation>().Add(new EventGuestInvitation
            {
                Code = InvitationHelper.GenerateCode(),
                EventGuestId = eventGuest.Id,
                EventInvitationId = eventInvitationId
            });

        foreach (var eventGuestInvitation in deletedEventGuestInvitations)
            UnitOfWork.Set<EventGuestInvitation>().Delete(eventGuestInvitation.Id);
    }

    private void UpdateEventGuestRoles(EventGuest eventGuest, IEnumerable<Guid> eventRoleIds)
    {
        var eventGuestRoles = UnitOfWork.Set<EventGuestRole>().GetAll().AsNoTracking()
            .Where(_ => _.EventGuestId == eventGuest.Id);
        var newEventRoles = eventRoleIds.Except(eventGuestRoles.Select(_ => _.RoleId));
        var deletedEventGuestRoles = eventGuestRoles.Where(_ => !eventRoleIds.Contains(_.RoleId));

        foreach (var eventRoleId in newEventRoles)
            UnitOfWork.Set<EventGuestRole>().Add(new EventGuestRole
            {
                EventGuestId = eventGuest.Id,
                RoleId = eventRoleId
            });

        foreach (var eventGuestRole in deletedEventGuestRoles)
            UnitOfWork.Set<EventGuestRole>().Delete(eventGuestRole.Id);
    }

    public record EventGuestRequest(
        GuestController.GuestData? Guest,
        Guid EventId,
        Guid? GuestId,
        int? Seats,
        IEnumerable<Guid>? EventRoleIds,
        IEnumerable<Guid>? EventInvitationIds);
}