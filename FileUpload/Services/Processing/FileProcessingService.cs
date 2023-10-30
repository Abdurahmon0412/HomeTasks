using FileUpload.Models.Entities;
using FileUpload.Services.Foundations;

namespace FileUpload.Services.Processing;

public class FileProcessingService
{
    private readonly FileService _fileService;
    private readonly StorageFileService _storageFileService;

    public FileProcessingService(FileService fileService, StorageFileService storageFileService)
    {
        _fileService = fileService;
        _storageFileService = storageFileService;
    }

    public  async ValueTask<bool>  UploadFileAsync(IFormFile formFile, Guid userId)
    {
        var storageFile = new StorageFile
        {
            Id = Guid.NewGuid(),
            Name = formFile.Name,
            Extension = Path.GetExtension(formFile.Name),
            Size = formFile.Length,
            UserId = userId
        };

        await _storageFileService.CreateFileAsync(storageFile);
        return _fileService.UploadFile(formFile.OpenReadStream(), storageFile);
    }
}