using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Helpers;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class GuestController(IUnitOfWork unitOfWork, ILogger<GuestController> logger)
    : ApiBaseController<Guest, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GuestRequest request)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(request);

            UnitOfWork.BeginTransaction();

            var newGuest = await EntityRepository.Add(new Guest
            {
                EventId = request.EventId,
                Salutation = request.Salutation ?? string.Empty,
                FirstName = request.FirstName,
                MiddleName = request.MiddleName ?? string.Empty,
                LastName = request.LastName,
                Suffix = request.Suffix ?? string.Empty,
                NickName = request.Nickname ?? string.Empty
            });

            UpdateGuestInvitations(newGuest, request.InvitationIds ?? []);
            UpdateGuestRoles(newGuest, request.RoleIds ?? []);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<Guest>(string.Empty) { Data = newGuest });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] GuestRequest request)
    {
        try
        {
            var guest = await EntityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(guest);

            UnitOfWork.BeginTransaction();

            guest.Salutation = request.Salutation ?? string.Empty;
            guest.FirstName = request.FirstName;
            guest.MiddleName = request.MiddleName ?? string.Empty;
            guest.LastName = request.LastName;
            guest.Suffix = request.Suffix ?? string.Empty;
            guest.NickName = request.Nickname ?? string.Empty;

            UnitOfWork.Set<Guest>().Update(guest);

            UpdateGuestInvitations(guest, request.InvitationIds ?? []);
            UpdateGuestRoles(guest, request.RoleIds ?? []);

            EntityRepository.Update(guest);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            guest = await EntityRepository.GetAll()
                .Where(_ => _.Id == id)
                .FirstOrDefaultAsync();

            return Ok(new OkResponse<Guest>(string.Empty) { Data = guest });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    [AllowAnonymous]
    [HttpGet("[action]")]
    public IActionResult Verify(string name)
    {
        var guest = EntityRepository.GetAll().AsNoTracking()
            .Where(_ => EF.Functions.Like(_.FirstName, $"%{name}%") ||
                        EF.Functions.Like(_.LastName, $"%{name}%") ||
                        EF.Functions.Like(_.NickName, $"%{name}%"));

        if (!guest.Any() || guest.Count() > 1)
            return BadRequest(new { Title = "Sorry, I could not find your name on the list..." });

        var guestInvitation = UnitOfWork.Set<GuestInvitation>().GetAll().AsNoTracking()
            .FirstOrDefault(_ => _.GuestId == guest.FirstOrDefault().Id);

        if (guestInvitation == null)
            return BadRequest(new { Title = "Sorry, there is no invitation associated with that name..." });

        return Ok(new OkResponse<GuestInvitation>(string.Empty) { Data = guestInvitation });
    }

    private void UpdateGuestInvitations(Guest guest, IEnumerable<Guid> invitationIds)
    {
        var guestInvitations = UnitOfWork.Set<GuestInvitation>().GetAll().AsNoTracking()
            .Where(_ => _.GuestId == guest.Id);
        var newInvitationIds =
            invitationIds.Except(guestInvitations.Select(_ => _.InvitationId));
        var deletedGuestInvitations =
            guestInvitations.Where(_ => !invitationIds.Contains(_.InvitationId));

        foreach (var invitationId in newInvitationIds)
            UnitOfWork.Set<GuestInvitation>().Add(new GuestInvitation
            {
                Code = InvitationHelper.GenerateCode(),
                GuestId = guest.Id,
                InvitationId = invitationId
            });

        foreach (var guestInvitation in deletedGuestInvitations)
            UnitOfWork.Set<GuestInvitation>().Delete(guestInvitation.Id);
    }

    private void UpdateGuestRoles(Guest guest, IEnumerable<Guid> roleIds)
    {
        var guestRoles = UnitOfWork.Set<GuestRole>().GetAll().AsNoTracking()
            .Where(_ => _.GuestId == guest.Id);
        var newRoles = roleIds.Except(guestRoles.Select(_ => _.RoleId));
        var deletedGuestRoles = guestRoles.Where(_ => !roleIds.Contains(_.RoleId));

        foreach (var roleId in newRoles)
            UnitOfWork.Set<GuestRole>().Add(new GuestRole
            {
                GuestId = guest.Id,
                RoleId = roleId
            });

        foreach (var guestRole in deletedGuestRoles)
            UnitOfWork.Set<GuestRole>().Delete(guestRole.Id);
    }

    public override async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var guestRoles = UnitOfWork.Set<GuestRole>().GetAll().Where(_ => _.GuestId == id);

            foreach (var guestRole in guestRoles) UnitOfWork.Set<GuestRole>().Delete(guestRole.Id);

            var guestInvitations = UnitOfWork.Set<GuestInvitation>().GetAll().Where(_ => _.GuestId == id);

            foreach (var guestInvitation in guestInvitations)
                UnitOfWork.Set<GuestInvitation>().Delete(guestInvitation.Id);

            EntityRepository.Delete(id);

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<Guid>(string.Empty) { Data = id });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    public override async Task<IActionResult> DeleteAll(IEnumerable<Guid> ids)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            foreach (var id in ids)
            {
                var guestRoles = UnitOfWork.Set<GuestRole>().GetAll().Where(_ => _.GuestId == id);

                foreach (var guestRole in guestRoles) UnitOfWork.Set<GuestRole>().Delete(guestRole.Id);

                var guestInvitations = UnitOfWork.Set<GuestInvitation>().GetAll().Where(_ => _.GuestId == id);

                foreach (var guestInvitation in guestInvitations)
                    UnitOfWork.Set<GuestInvitation>().Delete(guestInvitation.Id);

                EntityRepository.Delete(id);
            }

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<IEnumerable<Guid>>(string.Empty) { Data = ids });
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            await UnitOfWork.RollbackTransactionAsync();
            return Problem(ex.Message);
        }
    }

    public record GuestRequest(
        Guid EventId,
        string? Salutation,
        string FirstName,
        string LastName,
        string? MiddleName,
        string? Nickname,
        string? Suffix,
        IEnumerable<Guid>? RoleIds,
        IEnumerable<Guid>? InvitationIds);
}