using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers;

public class ZoneController(IUnitOfWork unitOfWork, ILogger<ZoneController> logger)
    : ApiBaseController<Zone, Guid>(unitOfWork, logger)
{
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ZoneRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Name);

        return await base.Post(new Zone
        {
            EventId = request.EventId,
            Name = request.Name,
            Configuration = request.Configuration ?? string.Empty,
            Capacity = request.Capacity
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] ZoneRequest request)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Name);

        var zone = await EntityRepository.Get(id);

        ArgumentNullException.ThrowIfNull(zone);

        zone.EventId = request.EventId;
        zone.Name = request.Name;
        zone.Configuration = request.Configuration ?? string.Empty;
        zone.Capacity = request.Capacity;

        return await base.Put(zone);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> UpdateZones([FromBody] IEnumerable<ZoneRequest> zoneRequests)
    {
        ArgumentNullException.ThrowIfNull(zoneRequests);

        var zoneRequestIds = zoneRequests.Select(_ => _.Id);

        var zones = UnitOfWork.Set<Zone>().GetAll().AsNoTracking()
            .Include(_ => _.ZoneSeats)
            .Where(_ => zoneRequestIds.Contains(_.Id));

        try
        {
            UnitOfWork.BeginTransaction();

            foreach (var request in zoneRequests)
            {
                var zone = zones.FirstOrDefault(_ => _.Id == request.Id);

                ArgumentNullException.ThrowIfNull(zone);

                foreach (var zoneSeatRequest in request.ZoneSeats)
                    if (!zone.ZoneSeats.Any(_ => _.GuestId == zoneSeatRequest.GuestId))
                        UnitOfWork.Set<ZoneSeat>().Add(new ZoneSeat
                        {
                            ZoneId = zone.Id,
                            Configuration = string.Empty,
                            GuestId = zoneSeatRequest.GuestId
                        });

                foreach (var zoneSeat in zone.ZoneSeats)
                    if (!request.ZoneSeats.Any(_ => _.GuestId == zoneSeat.GuestId))
                        UnitOfWork.Set<ZoneSeat>().Delete(zoneSeat.Id);
            }

            await UnitOfWork.SaveChangesAsync();
            await UnitOfWork.CommitTransactionAsync();

            return Ok(new OkResponse<IEnumerable<ZoneRequest>>(string.Empty) { Data = zoneRequests });
        }
        catch (Exception e)
        {
            await UnitOfWork.RollbackTransactionAsync();
            logger.LogError(e.Message, e);
            return Problem(e.Message);
        }
    }

    public record ZoneRequest(
        Guid Id,
        Guid EventId,
        string Name,
        string? Configuration,
        int Capacity,
        IEnumerable<ZoneSeatController.ZoneSeatRequest>? ZoneSeats);
}