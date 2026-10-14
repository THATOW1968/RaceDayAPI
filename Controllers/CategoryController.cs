using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Database;
using RaceDayAPI.Database;
using RaceDayAPI.Models;

namespace RaceDayAPI.Controllers
{//start of namespace
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {//start of class
        private readonly RaceDayContext _context;

        public CategoryController(RaceDayContext context)
        {//start of category controller
            _context = context;
        }//end of category controller

        // Organiser creates category
        [HttpPost("create")]
        public IActionResult CreateCategory(Category newCategory)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return Ok("Category created successfully!");
        }

        // View all categories
        [HttpGet("all")]
        public IActionResult GetCategories()
        {
            return Ok(_context.Categories.ToList());
        }
    }//end of class
}//end of namespace

