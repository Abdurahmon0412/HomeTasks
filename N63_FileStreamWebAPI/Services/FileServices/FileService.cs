using N63_FileStreamWebAPI.Interfaces.FileServices;
using N63_FileStreamWebAPI.Models.Storage;

namespace N63_FileStreamWebAPI.Services.FileServices;

public class FileService : IFileService
{
    private readonly IStorageFileService _storageFileService;

    public FileService(IStorageFileService storageFileService)
    {
        _storageFileService = storageFileService;
    }

    public bool UploadAsync(FileStream file, string path)
    {
        using var newFileStream = File.Open(path, FileMode.CreateNew, FileAccess.Write);
            
        var newFile = file.CopyToAsync(newFileStream);

        if(newFile is null)
            return false;

        return true;

        //var createdFile = await _storageFileService.CreateStorageAsync(file.Name,userId);

        //var path = Path.Combine("User", newStorageFile.UserId.ToString(), "Profile", newStorageFile.Id.ToString());

        //var destinationFileStream = File.OpenWrite(path);

        //await inputStream.CopyToAsync(destinationFileStream);
        //return createdFile;
    }

    public bool Delete(string path)
        => _storageFileService.DeleteStorage(path);


}