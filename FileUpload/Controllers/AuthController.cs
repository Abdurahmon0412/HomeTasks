using FileUpload.Models.Identity;
using FileUpload.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")] 
    public async ValueTask<IActionResult> RegisterAsync([FromBody] RegistrationDetails registrationDetails)
    {
        var result = await _authService.RegisterAsync(registrationDetails);
        return Ok(result);
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> LoginAsync([FromBody] LoginDetails loginDetails)
    {
        return Ok(await _authService.LoginAsync(loginDetails));
    }
}
