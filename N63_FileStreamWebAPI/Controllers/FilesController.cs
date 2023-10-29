using Microsoft.AspNetCore.Mvc;
using N63_FileStreamWebAPI.Interfaces.FileServices;

namespace N63_FileStreamWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    public readonly IFileService _fileService;

    public FilesController(IFileService fileService) => _fileService = fileService;

    [HttpPost("upload")]
    public async ValueTask<IActionResult> CreateFileAsync([FromBody] string path)
    {

        var inputStream = System.IO.File.OpenRead(path);

       // var createdFile = 
        return Ok(inputStream);
    }
}
