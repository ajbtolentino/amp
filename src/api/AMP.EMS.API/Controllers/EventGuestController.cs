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
        var eventGuest = await entityRepository.GetAll()
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

    public override async Task<IActionResult> GetAll()
    {
        var eventGuests = entityRepository.GetAll()
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
        var eventGuestInvitations = unitOfWork.Repository<EventGuestInvitation>().GetAll()
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

            unitOfWork.BeginTransaction();

            var newGuest = await unitOfWork.Repository<Guest>().Add(new Guest
            {
                FirstName = request.Guest.FirstName,
                LastName = request.Guest.LastName,
                NickName = request.Guest.Nickname ?? string.Empty,
                PhoneNumber = request.Guest.PhoneNumber ?? string.Empty
            });

            var newEventGuest = await entityRepository.Add(new EventGuest
            {
                EventId = request.EventId,
                GuestId = newGuest.Id,
                Seats = request.Seats ?? 1
            });

            UpdateEventGuestInvitations(newEventGuest, request.EventInvitationIds ?? []);
            UpdateEventGuestRoles(newEventGuest, request.EventRoleIds ?? []);

            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<EventGuest>(string.Empty) { Data = newEventGuest });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await unitOfWork.RollbackTransactionAsync();
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
            var eventGuest = await entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventGuest);

            unitOfWork.BeginTransaction();

            var guest = await unitOfWork.Repository<Guest>().Get(eventGuest.GuestId);

            ArgumentNullException.ThrowIfNull(guest);

            guest.FirstName = request.Guest.FirstName;
            guest.LastName = request.Guest.LastName;
            guest.NickName = request.Guest.Nickname ?? string.Empty;
            guest.PhoneNumber = request.Guest.PhoneNumber ?? string.Empty;

            unitOfWork.Repository<Guest>().Update(guest);

            eventGuest.Seats = request.Seats ?? 0;

            UpdateEventGuestInvitations(eventGuest, request.EventInvitationIds ?? []);
            UpdateEventGuestRoles(eventGuest, request.EventRoleIds ?? []);

            entityRepository.Update(eventGuest);

            await unitOfWork.SaveChangesAsync();
            await unitOfWork.CommitTransactionAsync();

            eventGuest = await entityRepository.GetAll()
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();

            return Ok(new OkResponse<EventGuest>(string.Empty) { Data = eventGuest });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await unitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    private void UpdateEventGuestInvitations(EventGuest eventGuest, IEnumerable<Guid> eventInvitationIds)
    {
        var eventGuestInvitations = unitOfWork.Repository<EventGuestInvitation>().GetAll().AsNoTracking()
            .Where(_ => _.EventGuestId == eventGuest.Id);
        var newEventInvitationIds =
            eventInvitationIds.Except(eventGuestInvitations.Select(_ => _.EventInvitationId));
        var deletedEventGuestInvitations =
            eventGuestInvitations.Where(_ => !eventInvitationIds.Contains(_.EventInvitationId));

        foreach (var eventInvitationId in newEventInvitationIds)
            unitOfWork.Repository<EventGuestInvitation>().Add(new EventGuestInvitation
            {
                Code = InvitationHelper.GenerateCode(),
                EventGuestId = eventGuest.Id,
                EventInvitationId = eventInvitationId
            });

        foreach (var eventGuestInvitation in deletedEventGuestInvitations)
            unitOfWork.Repository<EventGuestInvitation>().Delete(eventGuestInvitation.Id);
    }

    private void UpdateEventGuestRoles(EventGuest eventGuest, IEnumerable<Guid> eventRoleIds)
    {
        var eventGuestRoles = unitOfWork.Repository<EventGuestRole>().GetAll().AsNoTracking()
            .Where(_ => _.EventGuestId == eventGuest.Id);
        var newEventRoles = eventRoleIds.Except(eventGuestRoles.Select(_ => _.RoleId));
        var deletedEventGuestRoles = eventGuestRoles.Where(_ => !eventRoleIds.Contains(_.RoleId));

        foreach (var eventRoleId in newEventRoles)
            unitOfWork.Repository<EventGuestRole>().Add(new EventGuestRole
            {
                EventGuestId = eventGuest.Id,
                RoleId = eventRoleId
            });

        foreach (var eventGuestRole in deletedEventGuestRoles)
            unitOfWork.Repository<EventGuestRole>().Delete(eventGuestRole.Id);
    }

    public record EventGuestRequest(
        GuestController.GuestData? Guest,
        Guid EventId,
        Guid? GuestId,
        int? Seats,
        IEnumerable<Guid>? EventRoleIds,
        IEnumerable<Guid>? EventInvitationIds);
}