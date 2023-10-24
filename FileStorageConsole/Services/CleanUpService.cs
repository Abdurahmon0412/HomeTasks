using FileStorageConsole.Interfaces;
using FileStorageConsole.Models;

namespace FileStorageConsole.Services;

public class CleanUpService : ICleanUpService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public CleanUpService(IDirectoryService directoryService, IFileService fileService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public async ValueTask<List<string>> CleanUpAsync(User user)
    {
        var absalutePath = Path.Combine(Directory.GetCurrentDirectory(), "User", user.Id.ToString());

        await CleanProfileFolderAsync(Path.Combine(absalutePath, "Profile"));
        
        return await CleanResumeFolderAsync(Path.Combine(absalutePath, "Resume"));
    }

    private ValueTask<List<string>> CleanResumeFolderAsync(string path)
    {
        var validExtensions = new List<string> 
        {
            ".pdf",
            ".docx",
            ".txt"
        };

        var invalidFiles = new List<string>();

        foreach (var file in _directoryService.GetFiles(path))
            if (!validExtensions.Contains(_fileService.GetFilesExtentions(file)))
                invalidFiles.Add(file);

        return new ValueTask<List<string>> (invalidFiles);
    }

    private ValueTask CleanProfileFolderAsync(string path) 
    {
        var validImageExtensions = new List<string>
        {
            ".png",
            ".jpg",
            ".webm",
            ".img"
        };

        foreach(var file in _directoryService.GetFiles(path))
            if(!validImageExtensions.Contains(_fileService.GetFilesExtentions(file))
                || (_fileService.GetFileSize(file)) / 1024 < 60)
                _fileService.DeleteFile(file);

        return ValueTask.CompletedTask;
    }
}