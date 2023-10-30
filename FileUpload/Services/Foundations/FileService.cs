using FileUpload.Models.Constants;
using FileUpload.Models.Entities;
using FileUpload.Models.Settings;
using Microsoft.Extensions.Options;

namespace FileUpload.Services.Foundations;

public class FileService
{
    private readonly FileSettings _fileSettings;

    public FileService(IOptions< FileSettings> fileSettings ) => _fileSettings = fileSettings.Value;
    
    public bool UploadFile(Stream file, StorageFile storageFile)
    {
        var directoryPath = _fileSettings.FilePath
            .Replace(FilePathConstants.FileIdToken, storageFile.Id.ToString())
            .Replace(FilePathConstants.UserIdToken, storageFile.UserId.ToString());

        CreateDirectory(directoryPath);

        var filePath = Path.Combine(directoryPath, storageFile.Name);

        using var fileStream = new FileStream(filePath, FileMode.Create);

        file.CopyTo(fileStream);

        return true;
    }

    public void CreateDirectory(string directoryPaht) 
        => Directory.CreateDirectory(directoryPaht);
}