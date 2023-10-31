using Identity.Application.Common.Identity.Models;
using Identity.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("register")]
    public async ValueTask<IActionResult> RegisterAsync([FromBody] RegistrationDetails registrationDetails)
       => Ok(await _authService.RegisterAsync(registrationDetails));

    [HttpPost("login")]
    public async ValueTask<IActionResult> LoginAsync([FromBody] LoginDetails loginDetails)
        => Ok(await _authService.LogingAsync(loginDetails));
}