using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Database;
using RaceDayAPI.Database;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{//start of namespace
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentController : ControllerBase
    {//start of class
        private readonly RaceDayContext _context;

        public EnrolmentController(RaceDayContext context)
        {
            _context = context;
        }

        // Participant enrols in event
        [HttpPost("enrol")]
        public IActionResult Enrol(int userId, int eventId, int categoryId)
        {
            var enrolment = new Enrolment { UserId = userId, EventId = eventId, CategoryId = categoryId };
            _context.Enrolments.Add(enrolment);
            _context.SaveChanges();
            return Ok("Enrolment successful!");
        }

        // Organiser views enrolments for an event
        [HttpGet("event/{eventId}")]
        public IActionResult GetEnrolments(int eventId)
        {
            var enrolments = _context.Enrolments.Where(e => e.EventId == eventId).ToList();
            return Ok(enrolments);
        }
    }//end of class
}//end of namespace

