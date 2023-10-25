using FileExplorerApplication_Task.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorerAPI_Task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriveControllers : ControllerBase
{
    private readonly IDriveService _driveService;

    public DriveControllers(IDriveService driveService) => _driveService = driveService;

    [HttpGet("drives")]
    public async ValueTask<IActionResult> GetAsync()
    {
       var result =  await _driveService.GetAsync();

        return result.Any() ? Ok(result) : NotFound();
    }
}