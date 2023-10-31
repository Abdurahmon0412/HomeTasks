using Identity.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountSerive _accountService;

    public AccountsController(IAccountSerive accountSerive)
    {
        _accountService = accountSerive;
    }

    [HttpPut("verification/{token}")]
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
        => Ok(await _accountService.VerificateAsync(token));
}
