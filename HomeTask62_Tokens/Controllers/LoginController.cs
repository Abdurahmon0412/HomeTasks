using HomeTask62_Tokens.Models.Dtos;
using HomeTask62_Tokens.Services;
using Microsoft.AspNetCore.Mvc;

namespace HomeTask62_Tokens.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly LoginService _loginService;

    public LoginController(LoginService loginService) => _loginService = loginService;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationDetails registrationDetails)
    {
        var result = await _loginService.RegisterAsync(registrationDetails);
        return Ok(result);
    }

    [HttpPost("login")]
    
    public async Task<IActionResult> Login([FromBody] LoginDetails loginDetails)
    {
        var result = await _loginService.LoginAsync(loginDetails);

        return Ok(result);
    }
}