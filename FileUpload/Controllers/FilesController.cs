using FileUpload.Models.Constants;
using FileUpload.Services.Processing;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers;

public class FilesController : ControllerBase
{
    private readonly FileProcessingService _fileProcessingService;

    public FilesController(FileProcessingService fileProcessingService) 
        => _fileProcessingService = fileProcessingService;

    [HttpPost("upload")]

    public async ValueTask<IActionResult> UploadFileAsync(IFormFile file)
    {
        var userId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimConstants.UserId)?.Value;

        if (userId == null)
        {
            throw new ArgumentException();
        }
        return Ok(await _fileProcessingService.UploadFileAsync(file, Guid.Parse(userId)));
    }
}