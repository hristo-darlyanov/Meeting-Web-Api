using MeetingsWebApi.DTO.Request;
using MeetingsWebApi.DTO.Response;
using MeetingsWebApi.Service.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MeetingsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingsService Meetingservice;

        public MeetingsController(IMeetingsService MeetingsService)
        {
            Meetingservice = MeetingsService;
        }

        // GET:
        [HttpGet]
        public ActionResult<IEnumerable<MeetingsResponseDTO>> GetMeetings()
        {

            return Meetingservice.GetAll();
        }

        // GET:
        [HttpGet("{id}")]
        public ActionResult<MeetingsResponseDTO> GetMeetings(int id)
        {
            var Meetings = Meetingservice.GetMeetings(id);

            if (Meetings == null)
            {
                return NotFound();
            }

            return Meetings;
        }

        // PUT:
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeetings(int id, MeetingsRequestDTO Meetings)
        {
            await Meetingservice.UpdateMeetings(id, Meetings);

            return NoContent();
        }

        // POST:
        [HttpPost]
        public async Task<ActionResult<MeetingsResponseDTO>> PostMeetings(MeetingsRequestDTO Meetings)
        {
            int MeetingsId = await Meetingservice.CreateMeetings(Meetings);

            return CreatedAtAction("GetMeetings", new { id = MeetingsId }, Meetings);
        }

        // DELETE:
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeetings(int id)
        {
            var deleted = await Meetingservice.DeleteMeetings(id);
            if (deleted == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
