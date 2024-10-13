using System.Security.Claims;
using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class InvitationController(IUnitOfWork unitOfWork) : ApiBaseController<Invitation, Guid>(unitOfWork)
    {
        public record InvitationData(string Code, Guid EventId, Guid GuestId, int MaxGuests, bool LimitedView);

        // [HttpGet]
        // [Route("{id}")]
        // [AllowAnonymous]
        // public new async Task<IActionResult> Get(Guid id)
        // {
        //     var invitation = await this.entityRepository.Get(id);

        //     return Ok(new OkResponse<Invitation>(string.Empty) { Data = invitation });
        // }

        [HttpGet]
        [Route("{code}/[action]")]
        [AllowAnonymous]
        public IActionResult RSVP(string code)
        {
            var invitation = unitOfWork.Repository<Invitation>().GetAll().Include(_ => _.Guest).FirstOrDefault(_ => _.Code == code);

            if (invitation == null) return BadRequest();

            return Ok(new OkResponse<Invitation>(string.Empty) { Data = invitation });
        }

        [HttpGet]
        [Route("{eventId}/[action]")]
        public IActionResult Details(Guid? eventId)
        {
            if (!eventId.HasValue)
                return base.GetAll();

            var collection = base.entityRepository.GetAll().AsNoTracking()
                                .Where(_ => _.EventId == eventId)
                                .Include(_ => _.Guest);

            return Ok(new OkResponse<IEnumerable<Invitation>>(string.Empty) { Data = collection });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvitationData data)
        {
            return await base.Post(new Invitation
            {
                Code = data.Code,
                EventId = data.EventId,
                GuestId = data.GuestId,
                MaxGuests = data.MaxGuests,
                LimitedView = data.LimitedView
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] InvitationData data)
        {
            var entity = await this.entityRepository.Get(id);

            if (entity == null) return BadRequest();

            entity.Code = data.Code;
            entity.EventId = data.EventId;
            entity.GuestId = data.GuestId;
            entity.MaxGuests = data.MaxGuests;
            entity.DateUpdated = DateTime.Now;
            entity.LimitedView = data.LimitedView;

            return await base.Put(entity);
        }
    }
}
