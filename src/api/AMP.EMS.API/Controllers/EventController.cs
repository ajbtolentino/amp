using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class EventController(IUnitOfWork unitOfWork, ILogger<EventController> logger)
    : ApiBaseController<Event, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult Accounts(Guid eventId)
    {
        var eventAccounts = UnitOfWork.Set<EventAccount>().GetAll()
            .Where(eventAccount => eventAccount.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventAccount>>(string.Empty) { Data = eventAccounts });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult Roles(Guid eventId)
    {
        var roles = UnitOfWork.Set<Role>().GetAll().Where(role => role.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<Role>>(string.Empty) { Data = roles });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult Guests(Guid eventId)
    {
        var guests = UnitOfWork.Set<Guest>().GetAll()
            .Where(guest => guest.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<Guest>>(string.Empty) { Data = guests });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult Invitations(Guid eventId)
    {
        var invitations = UnitOfWork.Set<Invitation>().GetAll().AsNoTracking()
            .Where(invitation => invitation.EventId == eventId);

        return Ok(new OkResponse<IEnumerable<Invitation>>(string.Empty) { Data = invitations });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult Transactions(Guid eventId)
    {
        var eventAccountIds = UnitOfWork.Set<EventAccount>().GetAll().AsNoTracking()
            .Where(eventAccount => eventAccount.EventId == eventId)
            .Select(_ => _.AccountId);

        var transactions = UnitOfWork.Set<Transaction>().GetAll().AsNoTracking()
            .Where(_ => (_.CreditAccountId.HasValue && eventAccountIds.Contains(_.CreditAccountId.Value)) ||
                        (_.DebitAccountId.HasValue && eventAccountIds.Contains(_.DebitAccountId.Value)))
            .Select(_ => new Transaction
            {
                Id = _.Id,
                CreditAccountId = _.CreditAccountId,
                DebitAccountId = _.DebitAccountId,
                TransactionDate = _.TransactionDate,
                Description = _.Description,
                ReferenceNumber = _.ReferenceNumber,
                TransactionTypeId = _.TransactionTypeId,
                Amount = _.CreditAccountId.HasValue && eventAccountIds.Contains(_.CreditAccountId.Value)
                    ? _.Amount
                    : _.Amount * -1
            });

        return Ok(new OkResponse<IEnumerable<Transaction>>(string.Empty) { Data = transactions });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult VendorContracts(Guid eventId)
    {
        var eventVendorContracts = UnitOfWork.Set<VendorContract>().GetAll()
            .Where(eventVendorContract => eventVendorContract.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<VendorContract>>(string.Empty) { Data = eventVendorContracts });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult VendorContractStates(Guid eventId)
    {
        var eventVendorContractStates = UnitOfWork.Set<VendorContractState>().GetAll()
            .Where(eventVendorContractState => eventVendorContractState.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<VendorContractState>>(string.Empty)
            { Data = eventVendorContractStates });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult VendorContractPaymentTypes(Guid eventId)
    {
        var eventVendorContractPaymentTypes = UnitOfWork.Set<VendorContractPaymentType>().GetAll()
            .Where(eventVendorContractPaymentType => eventVendorContractPaymentType.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<VendorContractPaymentType>>(string.Empty)
            { Data = eventVendorContractPaymentTypes });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult VendorContractPaymentStates(Guid eventId)
    {
        var eventVendorContractPaymentState = UnitOfWork.Set<VendorContractPaymentState>().GetAll()
            .Where(eventVendorContractPaymentState => eventVendorContractPaymentState.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<VendorContractPaymentState>>(string.Empty)
            { Data = eventVendorContractPaymentState });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult VendorTypeBudgets(Guid eventId)
    {
        var eventVendorTypeBudgets = UnitOfWork.Set<EventVendorTypeBudget>().GetAll()
            .Where(eventVendorContractPaymentState => eventVendorContractPaymentState.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventVendorTypeBudget>>(string.Empty)
            { Data = eventVendorTypeBudgets });
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventRequest request)
    {
        try
        {
            UnitOfWork.BeginTransaction();

            var eventType = UnitOfWork.Set<EventType>().GetAll().Include(_ => _.EventTypeRoles)
                .FirstOrDefault(_ => _.Id == request.EventTypeId);

            ArgumentNullException.ThrowIfNull(eventType);

            var newEvent = await EntityRepository.Add(new Event
            {
                Title = request.Title,
                EventTypeId = request.EventTypeId,
                Description = request.Description ?? string.Empty,
                Location = request.Location ?? string.Empty,
                Seats = request.Seats,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            });

            foreach (var role in eventType.EventTypeRoles.ToList())
                await UnitOfWork.Set<Role>().Add(new Role
                {
                    EventId = newEvent.Id,
                    Name = role.Name,
                    Description = role.Description
                });

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<Event>(string.Empty) { Data = newEvent });
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
    public async Task<IActionResult> Put(Guid id, [FromBody] EventRequest request)
    {
        var @event = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(@event);

        @event.Title = request.Title;
        @event.EventTypeId = request.EventTypeId;
        @event.Description = request.Description ?? string.Empty;
        @event.Location = request.Location ?? string.Empty;
        @event.Seats = request.Seats;
        @event.StartDate = request.StartDate;
        @event.EndDate = request.EndDate;

        return await base.Put(@event);
    }

    public record EventRequest(
        string Title,
        Guid EventTypeId,
        string? Description,
        string? Location,
        int Seats,
        DateTime StartDate,
        DateTime EndDate);
}