using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Database;
using RaceDayAPI.Database;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{//start of namespace
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {//start of class
        private readonly RaceDayContext _context;

        public EventController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public IActionResult CreateEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return Ok("Event created successfully!");
        }

        [HttpGet("all")]
        public IActionResult GetEvents()
        {
            return Ok(_context.Events.ToList());
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateEvent(int id, Event updatedEvent)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();

            ev.Name = updatedEvent.Name;
            ev.Description = updatedEvent.Description;
            ev.Date = updatedEvent.Date;
            ev.Location = updatedEvent.Location;
            ev.Distance = updatedEvent.Distance;
            ev.EventType = updatedEvent.EventType;

            _context.SaveChanges();
            return Ok("Event updated successfully!");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            _context.SaveChanges();
            return Ok("Event deleted successfully!");
        }
    }//end of class
}//end of namespace
