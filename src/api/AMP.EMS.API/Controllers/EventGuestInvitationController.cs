using System.Security.Claims;
using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventGuestInvitationController(IUnitOfWork unitOfWork) : ApiBaseController<EventGuestInvitation, Guid>(unitOfWork)
    {
        public record EventGuestInvitationData(string Code, Guid EventInvitationId, Guid GuestId, int MaxGuests, bool LimitedView);

        [HttpGet]
        [Route("{code}/[action]")]
        [AllowAnonymous]
        public IActionResult RSVP(string code)
        {
            var invitation = unitOfWork.Repository<EventGuestInvitation>().GetAll()
                                    .Include(_ => _.EventGuest).FirstOrDefault(_ => _.Code == code);

            if (invitation == null) return BadRequest();

            return Ok(new OkResponse<EventGuestInvitation>(string.Empty) { Data = invitation });
        }

        [HttpGet]
        [Route("{eventInvitationId}/[action]")]
        public IActionResult Details(Guid? eventInvitationId)
        {
            if (!eventInvitationId.HasValue)
                return base.GetAll();

            var collection = base.entityRepository.GetAll().AsNoTracking()
                                .Where(_ => _.EventInvitationId == eventInvitationId)
                                .Include(_ => _.EventGuest);

            return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = collection });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestInvitationData data)
        {
            return await base.Post(new EventGuestInvitation
            {
                Code = data.Code,
                EventInvitationId = data.EventInvitationId,
                EventGuestId = data.GuestId
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestInvitationData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.Code = data.Code;
            entity.EventInvitationId = data.EventInvitationId;
            entity.EventGuestId = data.GuestId;

            return await base.Put(entity);
        }
    }
}
