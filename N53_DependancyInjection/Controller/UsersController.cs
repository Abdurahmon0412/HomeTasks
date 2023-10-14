using HometaskN48_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using N53_DependancyInjection.Models;

namespace N53_HT1.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var result = _userService.Get(user => true);

        return result.Any() ? Ok(result) : BadRequest();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] User user)
    {
        var result = await _userService.CreateAsync(user);

        return Ok(result);
    }
}