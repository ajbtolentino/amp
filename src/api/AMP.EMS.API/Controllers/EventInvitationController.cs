using AMP.Core.Repository;
using AMP.EMS.API.Core.Entities;
using AMP.Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AMP.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventInvitationController(IUnitOfWork unitOfWork, ILogger<EventInvitationController> logger) : ApiBaseController<EventInvitation, Guid>(unitOfWork, logger)
    {
        public record EventInvitationData(string Name, string? Description, string? Html, Guid EventId);
        
        [HttpGet]
        [Route("{id:guid}/guests")]
        public IActionResult GetGuests(Guid id)
        {
            var eventGuestInvitations = unitOfWork.Repository<EventGuestInvitation>().GetAll()
                                    .Where(_ => _.EventInvitationId == id)
                                    .Include(_ => _.EventGuest).ThenInclude(_ => _.Guest)
                                    .Include(_ => _.EventGuestInvitationRsvps).ThenInclude(_ => _.EventGuestInvitationRsvpItems);

            ArgumentNullException.ThrowIfNull(eventGuestInvitations);
            
            return Ok(new OkResponse<IEnumerable<EventGuestInvitation>>(string.Empty) { Data = eventGuestInvitations});
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventInvitationData data)
        {
            return await base.Post(new EventInvitation
            {
                EventId = data.EventId,
                Name = data.Name,
                Description = data.Description ?? string.Empty,
                Html = data.Html ?? string.Empty
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] EventInvitationData data)
        {
            var eventInvitation = await this.entityRepository.Get(id);

            ArgumentNullException.ThrowIfNull(eventInvitation);

            eventInvitation.EventId = data.EventId;
            eventInvitation.Name = data.Name;
            eventInvitation.Description = data.Description ?? string.Empty;
            eventInvitation.Html = data.Html ?? string.Empty;

            return await base.Put(eventInvitation);
        }
    }
}
