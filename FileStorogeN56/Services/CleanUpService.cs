using FileStorogeN56.Interfaces;
using FileStorogeN56.Models;
namespace FileStorogeN56.Services;

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
        var absolutePaht = Path.Combine(Directory.GetCurrentDirectory(), "Users", user.Id.ToString());

        await CleanProfileFolderAsync(Path.Combine(absolutePaht, "Avatar"));

        return await CleanResumeFolderAsync(Path.Combine(absolutePaht, "Resume"));
    }

    private ValueTask<List<string>> CleanResumeFolderAsync(string path)
    {
        var validDocumentExtentions = new List<string>
        {
            ".pdf",
            ".docx",
            ".txt",
            ".cs",
            ".py",
            ".c",
            "cpp"
        };

        var invalidDocumentsExtentions = new List<string>();

        foreach(var file in _directoryService.GetFiles(path))
        {
            if(!validDocumentExtentions.Contains(_fileService.GetFileExtentions(file)))
                invalidDocumentsExtentions.Add(_fileService.GetFileExtentions(file));
        }

        return new ValueTask<List<string>>(invalidDocumentsExtentions);
    }

    private ValueTask<List<string>> CleanProfileFolderAsync(string path)
    {
        var validImageFileExtensions = new List<string>
        {
            ".png",
            ".jpg",
            ".webm",
            ".img"
        };

        foreach(var file in _directoryService.GetFiles(path))
        {
            if(!validImageFileExtensions.Contains(_fileService.GetFileExtentions(file))
                || (_fileService.GetFileSize(file) / 1024) <= 60)
                _fileService.DeleteFile(file);
        }

        return new ValueTask<List<string>>();
    }
}