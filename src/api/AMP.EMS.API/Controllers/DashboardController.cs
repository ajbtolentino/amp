using AMP.Core.Repository;
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
    public IActionResult Attendees(Guid eventId)
    {
        var attendees = unitOfWork.Set<Guest>().GetAll()
            .Include(_ => _.GuestInvitations)
            .AsNoTracking();

        return Ok(new
        {
            data = new
            {
                attendees
            }
        });
    }

    [HttpGet("{eventId:guid}/[action]")]
    public async Task<IActionResult> Budget(Guid eventId)
    {
        var budgets = await unitOfWork.Set<EventVendorTypeBudget>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId)
            .ToListAsync();

        var vendorContracts = await unitOfWork.Set<VendorContract>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId)
            .Select(_ => _.Id)
            .ToListAsync();

        var totalAmountDue = await unitOfWork.Set<VendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => vendorContracts.Contains(_.VendorContractId))
            .Select(_ => _.DueAmount)
            .ToListAsync();

        return Ok(new
        {
            data = new
            {
                totalAmount = budgets.Sum(_ => _.Amount),
                totalVendorTypes = budgets.Select(_ => _.VendorTypeId).Distinct().Count(),
                totalAmountDue = totalAmountDue.Sum(_ => _),
                data = budgets
            }
        });
    }

    [HttpGet("{eventId:guid}/[action]")]
    public async Task<IActionResult> Expenses(Guid eventId)
    {
        var vendorContracts = await unitOfWork.Set<VendorContract>().GetAll().AsNoTracking()
            .Where(_ => _.EventId == eventId)
            .Select(_ => _.Id)
            .ToListAsync();

        var settledTransactions = await unitOfWork.Set<VendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => vendorContracts.Contains(_.VendorContractId) && _.TransactionId.HasValue)
            .Select(_ => _.TransactionId)
            .ToListAsync();

        var unreconciledPayments = await unitOfWork.Set<VendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => vendorContracts.Contains(_.VendorContractId) && !_.TransactionId.HasValue)
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
                totalUnsettledTransactions = unreconciledPayments.Sum(_ => _)
            }
        });
    }
}