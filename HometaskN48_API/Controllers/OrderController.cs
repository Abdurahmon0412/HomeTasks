using HometaskN48_API.Models;
using HometaskN48_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HometaskN48_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult GetAllOrders([FromQuery] int pageToken,int pageSize)
        {
            var result = _orderService.Get(order => true);
            return result.Any() ? Ok(result) : NotFound();
        }

        [HttpPost("order")]
        public async ValueTask<IActionResult> CreateAsync([FromBody] Order order)
        {
            var result = await _orderService.CreateAsync(order);
            return CreatedAtAction(nameof(result),new {userId = result.UserId},result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateAsync([FromBody] Order order)
        {
            var result = await _orderService.UpdateAsync(order);
            return NoContent();
        }

        [HttpGet("{orderId}")]
        public async ValueTask<IActionResult> GetById([FromRoute] Guid orderid)
        {
            var result = await _orderService.GetByIdAsync(orderid);
            return result is not null ? Ok(result) : NotFound();
        }

    }
}
