using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Enums;
using AMP.Infrastructure.Extensions;
using AMP.Infrastructure.Filters;
using AMP.Infrastructure.Pagination;
using AMP.Infrastructure.Responses;
using AMP.Infrastructure.Sorting;
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
    public IActionResult Guests(Guid eventId, int pageNumber, int pageSize, string? search, string? sortField,
        SortDirection? sortDirection, [FromQuery] Guid[]? roleIds)
    {
        var query = UnitOfWork.Set<Guest>().GetAll().AsNoTracking()
            .Where(guest => guest.EventId == eventId);

        if (!string.IsNullOrEmpty(search))
            query = query.Where(_ =>
                EF.Functions.Like(_.FirstName, $"%{search}%") ||
                EF.Functions.Like(_.LastName, $"%{search}%") ||
                EF.Functions.Like(_.Salutation, $"%{search}%") ||
                EF.Functions.Like(_.Suffix, $"%{search}%"));

        if (roleIds != null && roleIds.Any())
            query = query.Include(_ => _.GuestRoles)
                .Where(_ => _.GuestRoles.Any(gr => roleIds.Contains(gr.RoleId))).AsNoTracking();

        if (!string.IsNullOrEmpty(sortField))
            query = query.ApplySorting(new SortingParameters
            {
                SortField = sortField,
                SortDirection = sortDirection ?? SortDirection.Ascending
            });

        var pagedResult = query.ApplyPagination(pageNumber, pageSize);

        return Ok(new OkResponse<PagedResult<Guest>>(string.Empty) { Data = pagedResult });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult UnseatedAttendees(Guid eventId)
    {
        var guests = UnitOfWork.Set<Guest>().GetAll()
            .Include(_ => _.ZoneSeats)
            .Where(guest => guest.EventId == eventId && !guest.ZoneSeats.Any())
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
    public IActionResult Timelines(Guid eventId)
    {
        var timelines = UnitOfWork.Set<Timeline>().GetAll().AsNoTracking()
            .Where(timeline => timeline.EventId == eventId)
            .OrderBy(_ => _.StartDate);

        return Ok(new OkResponse<IEnumerable<Timeline>>(string.Empty) { Data = timelines });
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
    public IActionResult UnreconciledPayments(Guid eventId)
    {
        var vendorContractIds = UnitOfWork.Set<VendorContract>().GetAll()
            .AsNoTracking()
            .Where(eventVendorContract => eventVendorContract.EventId == eventId)
            .Select(_ => _.Id);

        var unreconciledPayments = UnitOfWork.Set<VendorContractPayment>().GetAll().AsNoTracking()
            .Where(_ => vendorContractIds.Contains(_.VendorContractId) && !_.TransactionId.HasValue);

        return Ok(new OkResponse<IEnumerable<VendorContractPayment>>(string.Empty) { Data = unreconciledPayments });
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

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult Tasks(Guid eventId)
    {
        var eventTasks = UnitOfWork.Set<EventTask>().GetAll()
            .Where(eventTask => eventTask.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventTask>>(string.Empty)
            { Data = eventTasks });
    }

    [HttpGet]
    [Route("{eventId:guid}/[action]")]
    public IActionResult Zones(Guid eventId)
    {
        var zones = UnitOfWork.Set<Zone>().GetAll()
            .Include(_ => _.ZoneSeats)
            .ThenInclude(_ => _.Guest)
            .ThenInclude(_ => _.GuestInvitations)
            .Where(eventTask => eventTask.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<Zone>>(string.Empty)
            { Data = zones });
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

    public record GuestFilterRequest(
        int PageNumber,
        int PageSize,
        string? Search,
        string? SortField,
        SortDirection? SortDirection,
        IEnumerable<Filter> Filters);
}