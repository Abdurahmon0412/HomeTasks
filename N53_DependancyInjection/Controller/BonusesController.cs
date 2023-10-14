using Microsoft.AspNetCore.Mvc;
using N53_DependancyInjection.Models;
using N53_DependancyInjection.Services.Interfaces;

namespace N53_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BonusesController : ControllerBase
{
    private readonly IBonusService _bonusService;

    public BonusesController(IBonusService bonusService)
    {
        _bonusService = bonusService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = _bonusService.Get(bonus => true);
        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] Bonus bonus)
    {
        var result = await _bonusService.CreateAsync(bonus);
        return Ok(result);
    }
}
