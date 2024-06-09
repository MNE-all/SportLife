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
    }
}
