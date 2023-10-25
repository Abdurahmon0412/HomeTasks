using FileExplorerAPI_Task.Models.Dtos;
using FileExplorerApplication_Task.FileStorage.Models.Filtering;
using FileExplorerApplication_Task.FileStorage.Models.Storage;
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

    [HttpGet]
    public ValueTask<IActionResult> GetFiles([FromQuery] FilterModel filterModel, [FromServices] IWebHostEnvironment environment)
    {
        var allFiles = new List<StorageFile>();

        var files = GetAllFiles(environment.WebRootPath, allFiles)
            .Skip((filterModel.PageToken - 1) * filterModel.PageSize)
            .Take(filterModel.PageSize);

        return new ValueTask<IActionResult>(Ok(files));

    }

    private IList<StorageFile> GetAllFiles(string path, List<StorageFile> allFiles)
    {
        var files = new DirectoryInfo(path).GetFiles().ToList();

        var directories = Directory.GetDirectories(path);

        allFiles.AddRange(files.Select(fileInfo => new StorageFile
        {
            Name = fileInfo.Name,

            Path = fileInfo.FullName,

            DirectoryPath = fileInfo.DirectoryName!,

            Extension = fileInfo.Extension,

            Size = fileInfo.Length,
        }));

        foreach (var directory in directories)
            GetAllFiles(directory, allFiles);

        return allFiles;
    }
}