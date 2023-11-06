using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduCource.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserSettingsController : ControllerBase
{
    private readonly IEntityBaseService<UserSettings> _userSettings;

    public UserSettingsController(IEntityBaseService<UserSettings> userSettings)
    {
        _userSettings = userSettings;
    }

    [HttpGet]
    public async ValueTask<IActionResult> Get()
    {
        var userSettings = await _userSettings.Get(user => true).ToListAsync();
        return userSettings.Any() ? Ok(userSettings) : NotFound();
    }

    [HttpGet("{userId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid userId)
    {
        var userSettings = await _userSettings.GetByIdAsync(userId);
        return userSettings != null ? Ok(userSettings) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateAsync([FromBody] UserSettings userSettings)
    {
        var createdUserSettings = await _userSettings.CreateAsync(userSettings);
        return CreatedAtAction(nameof(GetById),
            new
            {
                userId = createdUserSettings.Id
            },
            createdUserSettings);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] UserSettings userSettings)
    {
        await _userSettings.UpdateAsync(userSettings);
        return Ok();
    }

    [HttpDelete("{settingsId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid settingsId)
    {
        var deletedUserSettings = await _userSettings.GetByIdAsync(settingsId);
        await _userSettings.DeleteAsync(deletedUserSettings);

        return Ok();
    }
}