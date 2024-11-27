using Microsoft.AspNetCore.Mvc;
using BogusExample.Core.Models;
using BogusExample.Core.Services;

namespace BogusExample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET api/user/generate?count=10
        [HttpGet("generate")]
        public IActionResult GenerateFakeUsers(int count = 10)
        {
            var users = _userService.GenerateFakeUsers(count);
            return Ok(users);
        }

        // POST api/user/adults
        [HttpPost("adults")]
        public IActionResult GetAdults([FromBody] List<User> users)
        {
            var adults = _userService.GetAdults(users);
            return Ok(adults);
        }
    }
}
