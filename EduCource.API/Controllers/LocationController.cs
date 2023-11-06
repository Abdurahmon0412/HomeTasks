using EduCource.Persistance.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduCource.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromServices] AppDbContext dbContext)
    {
        var results = await dbContext.Locations.ToListAsync();
        return Ok(results);
    }
}