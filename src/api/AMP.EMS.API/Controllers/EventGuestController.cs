using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static AMP.EMS.API.Controllers.GuestController;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuestController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuest, Guid>(unitOfWork)
    {
        public record EventGuestData(GuestData? Guest, Guid EventId, Guid? GuestId);

        [HttpGet]
        [Route("{eventId}/[action]")]
        public IActionResult Details(Guid? eventId)
        {
            if (!eventId.HasValue)
                return base.GetAll();

            var collection = base.entityRepository.GetAll()
                                .Include(_ => _.Guest)
                                .AsNoTracking()
                                .Where(_ => _.EventId == eventId);

            return Ok(new OkResponse<IEnumerable<EventGuest>>(string.Empty) { Data = collection });
        }

        public override async Task<IActionResult> Get(Guid id)
        {
            var entity = await this.entityRepository.GetAll()
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Guest)
                                    .FirstOrDefaultAsync();

            return Ok(new OkResponse<EventGuest>(string.Empty) { Data = entity });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestData data)
        {
            try
            {
                if (data.GuestId.HasValue)
                {
                    return await base.Post(new EventGuest
                    {
                        EventId = data.EventId,
                        GuestId = data.GuestId.Value
                    });
                }

                if (data.Guest != null)
                {
                    this.unitOfWork.BeginTransaction();

                    var newGuest = await this.unitOfWork.Repository<Guest>().Add(new Guest
                    {
                        FirstName = data.Guest.FirstName,
                        LastName = data.Guest.LastName,
                        NickName = data.Guest.Nickname ?? string.Empty,
                        PhoneNumber = data.Guest.PhoneNumber ?? string.Empty
                    });

                    var newEntity = await this.entityRepository.Add(new EventGuest
                    {
                        EventId = data.EventId,
                        GuestId = newGuest.Id
                    });

                    await this.unitOfWork.SaveChangesAsync();
                    await this.unitOfWork.CommitTransactionAsync();

                    return Ok(new OkResponse<EventGuest>(string.Empty) { Data = newEntity });
                }
            }
            catch
            {
                await this.unitOfWork.RollbackTransactionAsync();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestData data)
        {
            try
            {
                var entity = await this.entityRepository.Get(id);

                if (entity == null) return BadRequest();

                if (data.Guest == null && (data.EventId != entity.EventId || data.GuestId != entity.GuestId))
                {
                    entity.EventId = data.EventId;
                    entity.GuestId = data.GuestId.Value;

                    return await base.Put(entity);
                }

                if (data.Guest != null && data.GuestId.HasValue)
                {
                    this.unitOfWork.BeginTransaction();

                    var guest = await this.unitOfWork.Repository<Guest>().Get(data.GuestId);

                    guest.FirstName = data.Guest.FirstName;
                    guest.LastName = data.Guest.LastName;
                    guest.NickName = data.Guest.Nickname ?? string.Empty;
                    guest.PhoneNumber = data.Guest.PhoneNumber ?? string.Empty;

                    this.unitOfWork.Repository<Guest>().Update(guest);

                    await this.unitOfWork.SaveChangesAsync();
                    await this.unitOfWork.CommitTransactionAsync();

                    entity = await this.entityRepository.GetAll()
                                    .Where(_ => _.Id == id)
                                    .Include(_ => _.Guest)
                                    .FirstOrDefaultAsync();

                    return Ok(new OkResponse<EventGuest>(string.Empty) { Data = entity });
                }
            }
            catch
            {
                await this.unitOfWork.RollbackTransactionAsync();
            }

            return BadRequest();
        }
    }
}
