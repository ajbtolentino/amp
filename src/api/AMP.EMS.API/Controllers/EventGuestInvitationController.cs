using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.EMS.API.Helpers;
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
        public record EventGuestInvitationRequest(Guid EventInvitationId, Guid GuestId, string? Code, int MaxGuests);

        private record RsvpResponse(Guest Guest, EventGuestInvitation EventGuestInvitation, EventInvitation EventInvitation);

        [HttpGet]
        [Route("{code}/[action]")]
        [AllowAnonymous]
        public IActionResult Rsvp(string code)
        {
            var eventGuestInvitation = unitOfWork.Repository<EventGuestInvitation>().GetAll()
                .Include(eventGuestInvitation => eventGuestInvitation.EventInvitation)
                .Include(eventInvitation => eventInvitation.EventInvitation)
                .Include(eventGuestInvitation => eventGuestInvitation.EventGuest)
                    .ThenInclude(eventGuest => eventGuest.Guest)
                .FirstOrDefault(guestInvitation => guestInvitation.Code == code);

            ArgumentNullException.ThrowIfNull(eventGuestInvitation);

            return Ok(new OkResponse<EventGuestInvitation>(string.Empty) { Data = eventGuestInvitation });
        }

        [HttpGet]
        [Route("{eventInvitationId}/[action]")]
        public IActionResult Details(Guid? eventInvitationId)
        {
            // if (!eventInvitationId.HasValue)
            //     return base.GetAll();
            //
            // var collection = base.entityRepository.GetAll().AsNoTracking()
            //                     .Where(_ => _.EventInvitationId == eventInvitationId)
            //                     .Include(_ => _.EventGuest);
            //
            // return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = collection });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventGuestInvitationRequest request)
        {
            return await base.Post(new EventGuestInvitation()
            {
                EventInvitationId = request.EventInvitationId,
                Code = InvitationHelper.GenerateCode(),
                MaxGuests = request.MaxGuests
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventGuestInvitationRequest request)
        {
            var guestInvitation = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull((guestInvitation));

            if(!string.IsNullOrEmpty(request.Code))
                guestInvitation.Code = request.Code;
                
            guestInvitation.EventInvitationId = request.EventInvitationId;
            guestInvitation.MaxGuests = request.MaxGuests;
            
            return await base.Put(guestInvitation);
        }
    }
}
