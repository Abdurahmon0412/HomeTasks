using HometaskN48_API.Models;
using HometaskN48_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HometaskN48_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersControlller : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserOrders _userOrders;

        public UsersControlller(IUserService userService, IUserOrders userOrders)
        {
            _userService = userService;
            _userOrders = userOrders;
        }

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery]int pageToken,int pageSize)
        {
            var result = _userService.Get(user => true).Skip((pageToken - 1) * pageSize).Take(pageSize).ToList();
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateUser(User user)
        {
            var result = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(result), new {userId = result.Id}, result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateAsync(user);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _userService.GetByIdAsync(id);
            return result is null? Ok(result) : NotFound();
        }

        [HttpGet("{userId:Guid}/orders")]
        public IActionResult GetOrderById([FromRoute] Guid userId)
        {
            var result = _userOrders.GetUserOrders(userId);
            return result.Any() ? Ok(result) : NotFound();
        }
    }
}
