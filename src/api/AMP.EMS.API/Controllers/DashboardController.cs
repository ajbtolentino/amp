using AMP.Core.Repository;
using AMP.EMS.API.Core.Constants;
using AMP.EMS.API.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class DashboardController(IUnitOfWork unitOfWork, ILogger<EventController> logger) : ControllerBase
{
    [HttpGet("{eventId:guid}/[action]")]
    public async Task<IActionResult> GuestInvitations(Guid eventId)
    {
        var eventInvitationIds = unitOfWork.Set<EventInvitation>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId).Select(_ => _.Id);

        var eventGuests = unitOfWork.Set<EventGuest>().GetAll().Where(_ => _.EventId == eventId).AsNoTracking();

        var eventGuestInvitations = unitOfWork.Set<EventGuestInvitation>().GetAll().AsNoTracking()
            .Where(_ => eventInvitationIds.Contains(_.EventInvitationId));

        var eventGuestInvitationIds = eventGuestInvitations.Select(_ => _.Id);

        var eventGuestInvitationRsvps = unitOfWork.Set<EventGuestInvitationRsvp>().GetAll().AsNoTracking()
            .Where(_ => eventGuestInvitationIds.Contains(_.EventGuestInvitationId))
            .GroupBy(_ => _.EventGuestInvitationId);

        var accepted = await eventGuestInvitationRsvps.Where(_ =>
                _.OrderByDescending(__ => __.DateCreated).FirstOrDefault().Response == RsvpResponse.ACCEPT)
            .Select(_ => _.OrderByDescending(__ => __.DateCreated).FirstOrDefault().Id).ToListAsync();

        var declined = eventGuestInvitationRsvps.Where(_ =>
            _.OrderByDescending(__ => __.DateCreated).FirstOrDefault().Response == RsvpResponse.DECLINE);

        var secondaryGuests = await unitOfWork.Set<EventGuestInvitationRsvpItem>().GetAll().AsNoTracking()
            .Where(_ => accepted.Contains(_.EventGuestInvitationRsvpId))
            .GroupBy(_ => _.EventGuestInvitationRsvpId)
            .ToListAsync();

        return Ok(new
        {
            data = new
            {
                totalMainGuests = eventGuests.Count(),
                totalSecondaryGuests = secondaryGuests.Sum(_ => _.Skip(1).Count()),
                totalEventGuestInvitations = eventGuestInvitations.Count(),
                totalAccepted = accepted.Count(),
                totalDeclined = declined.Count()
            }
        });
    }

    [HttpGet("{eventId:guid}/[action]")]
    public async Task<IActionResult> Budget(Guid eventId)
    {
        var budgets = await unitOfWork.Set<EventVendorTypeBudget>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId)
            .ToListAsync();

        var vendorContracts = await unitOfWork.Set<EventVendorContract>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId)
            .Select(_ => _.Id)
            .ToListAsync();

        var totalAmountDue = await unitOfWork.Set<EventVendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => vendorContracts.Contains(_.EventVendorContractId))
            .Select(_ => _.DueAmount)
            .ToListAsync();

        return Ok(new
        {
            data = new
            {
                totalAmount = budgets.Sum(_ => _.Amount),
                totalVendorTypes = budgets.Select(_ => _.VendorTypeId).Distinct().Count(),
                totalAmountDue = totalAmountDue.Sum(_ => _)
            }
        });
    }

    [HttpGet("{eventId:guid}/[action]")]
    public async Task<IActionResult> Expenses(Guid eventId)
    {
        var vendorContracts = await unitOfWork.Set<EventVendorContract>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId)
            .Select(_ => _.Id)
            .ToListAsync();

        var settledTransactions = await unitOfWork.Set<EventVendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => vendorContracts.Contains(_.EventVendorContractId) && _.TransactionId.HasValue)
            .Select(_ => _.TransactionId)
            .ToListAsync();

        var unsettledTransactions = await unitOfWork.Set<EventVendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => vendorContracts.Contains(_.EventVendorContractId) && !_.TransactionId.HasValue)
            .Select(_ => _.DueAmount)
            .ToListAsync();

        var eventAccounts = await unitOfWork.Set<EventAccount>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId)
            .Select(_ => _.AccountId)
            .ToListAsync();

        var totalExpenses = await unitOfWork.Set<Transaction>().GetAll().AsNoTracking()
            .Where(_ => settledTransactions.Contains(_.Id) && _.DebitAccountId.HasValue &&
                        eventAccounts.Contains(_.DebitAccountId.Value))
            .Select(_ => _.Amount)
            .ToListAsync();

        return Ok(new
        {
            data = new
            {
                totalExpenses = totalExpenses.Sum(_ => _),
                totalUnsettledTransactions = unsettledTransactions.Sum(_ => _)
            }
        });
    }
}