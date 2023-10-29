using N63_FileStreamWebAPI.Interfaces.FileServices;
using N63_FileStreamWebAPI.Models.Storage;

namespace N63_FileStreamWebAPI.Services.FileServices;

public class FileProcessingService
{
    private readonly IFileService _fileService;
    private readonly IStorageFileService _storageFileService;

    public FileProcessingService(IFileService fileService, IStorageFileService storageFileService)
    {
        _fileService = fileService;
        _storageFileService = storageFileService;
    }

    public ValueTask<StorageFile> UploadAsync(FileStream fileStream)
    {
        var path = "";
        _fileService.UploadAsync(fileStream,path);

        return new ValueTask<StorageFile>();
    }
}
