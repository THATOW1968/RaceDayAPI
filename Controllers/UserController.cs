using Microsoft.AspNetCore.Mvc;
using RaceDayAPI.Database;
using RaceDayAPI.Database;
using RaceDayAPI.Models;
using System.Security.Cryptography;
using System.Text;

namespace RaceDayAPI.Controllers
{//start of namespace
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {//start of class
        private readonly RaceDayContext _context;

        public UserController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(string username, string password, string role)
        {//start of register
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var passwordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            var user = new User { Username = username, PasswordHash = passwordHash, Role = role };
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered successfully!");
        }//end of register

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {//start of login
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var passwordHash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.PasswordHash == passwordHash);

            if (user == null)
                return Unauthorized("Invalid credentials");

            return Ok($"Welcome {user.Role} {user.Username}!");
        }//end of login
    }//end of class
}//end of namespace

