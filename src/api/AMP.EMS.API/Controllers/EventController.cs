using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController(IUnitOfWork unitOfWork, ILogger<EventController> logger)
    : ApiBaseController<Event, Guid>(unitOfWork, logger)
{
    [HttpGet]
    [Route("{eventId:guid}/roles")]
    public IActionResult GetRoles(Guid eventId)
    {
        var eventRoles = UnitOfWork.Set<Role>().GetAll().Where(role => role.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<Role>>(string.Empty) { Data = eventRoles });
    }

    [HttpGet]
    [Route("{eventId:guid}/guests")]
    public IActionResult GetGuests(Guid eventId)
    {
        var eventGuests = UnitOfWork.Set<EventGuest>().GetAll()
            .Where(eventGuest => eventGuest.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventGuest>>(string.Empty) { Data = eventGuests });
    }

    [HttpGet]
    [Route("{eventId:guid}/invitations")]
    public IActionResult GetInvitations(Guid eventId)
    {
        var eventInvitations = UnitOfWork.Set<EventInvitation>().GetAll().AsNoTracking()
            .Where(eventInvitation => eventInvitation.EventId == eventId);

        return Ok(new OkResponse<IEnumerable<EventInvitation>>(string.Empty) { Data = eventInvitations });
    }

    [HttpGet]
    [Route("{eventId:guid}/vendorContracts")]
    public IActionResult GetVendorContracts(Guid eventId)
    {
        var eventVendorContracts = UnitOfWork.Set<EventVendorContract>().GetAll()
            .Where(eventVendorContract => eventVendorContract.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventVendorContract>>(string.Empty) { Data = eventVendorContracts });
    }

    [HttpGet]
    [Route("{eventId:guid}/vendorContractStates")]
    public IActionResult GetVendorContractStates(Guid eventId)
    {
        var eventVendorContractStates = UnitOfWork.Set<EventVendorContractState>().GetAll()
            .Where(eventVendorContractState => eventVendorContractState.EventId == eventId).AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventVendorContractState>>(string.Empty)
            { Data = eventVendorContractStates });
    }

    [HttpGet]
    [Route("{eventId:guid}/vendorContractPaymentTypes")]
    public IActionResult GetVendorContractPaymentTypes(Guid eventId)
    {
        var eventVendorContractPaymentTypes = UnitOfWork.Set<EventVendorContractPaymentType>().GetAll()
            .Where(eventVendorContractPaymentType => eventVendorContractPaymentType.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventVendorContractPaymentType>>(string.Empty)
            { Data = eventVendorContractPaymentTypes });
    }

    [HttpGet]
    [Route("{eventId:guid}/vendorContractPaymentStates")]
    public IActionResult GetVendorContractPaymentStates(Guid eventId)
    {
        var eventVendorContractPaymentState = UnitOfWork.Set<EventVendorContractPaymentState>().GetAll()
            .Where(eventVendorContractPaymentState => eventVendorContractPaymentState.EventId == eventId)
            .AsNoTracking();

        return Ok(new OkResponse<IEnumerable<EventVendorContractPaymentState>>(string.Empty)
            { Data = eventVendorContractPaymentState });
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