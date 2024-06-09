using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportLife.Context.Models;
using SportLife.Context;
using SportLife.Services;

namespace SportLife.API.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, SportLifeContext db)
        {
            _logger = logger;
            userService = new(db);
        }

        [HttpGet("GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return userService.GetUsers();
        }

        [HttpPost("PostUser")]
        public IActionResult AddUser(string login, string password)
        {
            var user = userService.Create(login, password);

            if (user == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        
        [HttpGet("login")]
        public ActionResult<string> Login(string login, string password)
        {
            return userService.Login(login, password);
        }

        [Authorize, HttpGet("show/password")]
        public string ShowPassword()
        {
            var  id= User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            return userService.ShowPassword(Guid.Parse(id));
        }
    }
}
