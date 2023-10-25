using FileExplorerApplication_Task.FileStorage.Models.Filtering;
using FileExplorerApplication_Task.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorerAPI_Task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService) => _fileService = fileService;

    [HttpGet("filesGet")]
    public async ValueTask<IActionResult> GeetFiles([FromQuery] StorageDriveEntryFilterModel filterModel, IWebHostEnvironment webHostEnvironment)
    {
        var result = await _fileService.GetFileByPathAsync(webHostEnvironment.WebRootPath );
        return result != null ?
            Ok(result)
            : BadRequest();
    }
}