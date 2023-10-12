using HomeTask52_Events.Models;
using HomeTask52_Events.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HomeTask52_Events.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountsController(IUserService userSercice)
        {
            _userService = userSercice;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUser([FromBody] User user)
        {
            var result = _userService.CreateAsync(user);
            return Ok(result);
        }

    }
}