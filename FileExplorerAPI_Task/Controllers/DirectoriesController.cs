using AutoMapper;
using FileExplorerAPI_Task.Models.Dtos;
using FileExplorerApplication_Task.FileStorage.Models.Filtering;
using FileExplorerApplication_Task.FileStorage.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExplorerAPI_Task.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectoriesController : ControllerBase
{
    private readonly IDirectoryService _directoryService;
    private readonly IDirectoryProcessingService _directoryProcessingService;
    private readonly IMapper _mapper;

    public DirectoriesController(IDirectoryService directoryService,
        IDirectoryProcessingService directoryProcessingService,
        IMapper mapper)
    {
        _directoryProcessingService = directoryProcessingService;
        _mapper = mapper;
        _directoryService = directoryService;
    }

    [HttpGet("root/entries")]
    public async ValueTask<IActionResult> GetRootEntriesAsync([FromQuery] StorageDirectoryEntryFilterModel filterModel, IWebHostEnvironment environment)
    {
        var result = await _directoryProcessingService.GetEntriesAsync(environment.WebRootPath, filterModel);

        return result.Any() ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{directoryPath}")]
    public async ValueTask<IActionResult> GetByDirectoryPath([FromRoute] string directoryPath)
    {
        var resultA = _directoryService.GetByPathAsync(directoryPath);
        var resultB = resultA != null ? _mapper.Map<StorageDirectoryDto>(resultA) : null;

        return resultB != null ? Ok(resultB) : NotFound();
    }
}