using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Database;
using RaceDayAPI.Database;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{//start of namespace
    [ApiController]
    [Route("api/[controller]")]
    public class ResultController : ControllerBase
    {//start of class
        private readonly RaceDayContext _context;

        public ResultController(RaceDayContext context)
        {
            _context = context;
        }

        // Organiser adds result
        [HttpPost("add")]
        public IActionResult AddResult(int userId, int eventId, double finishTime, int position)
        {
            var result = new Result { UserId = userId, EventId = eventId, FinishTime = finishTime, Position = position };
            _context.Results.Add(result);
            _context.SaveChanges();
            return Ok("Result added successfully!");
        }

        // Participant views their results
        [HttpGet("user/{userId}")]
        public IActionResult GetUserResults(int userId)
        {
            var results = _context.Results.Where(r => r.UserId == userId).ToList();
            return Ok(results);
        }
    }//end of class
}//end of namespace

