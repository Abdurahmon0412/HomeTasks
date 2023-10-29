using N63_FileStreamWebAPI.Interfaces.FileServices;
using N63_FileStreamWebAPI.Models.Storage;

namespace N63_FileStreamWebAPI.Services.FileServices;

public class StorageFileService : IStorageFileService
{
    private static readonly List<StorageFile> _storageFiles = new();

    public  ValueTask<StorageFile> CreateStorageAsync(string fileName, Guid userId)
    {
        var fileId = Guid.NewGuid();
        var path = Path.Combine("webroot", "Users", userId.ToString() , "Profile", fileId.ToString());

        var model = new StorageFile();
        model.Name = fileName;
        model.UserId = userId;
        model.Id = fileId;
        model.CreatedDate = DateTime.Now;
        model.Path = path;

        _storageFiles.Add(model); 

        return new ValueTask<StorageFile> (model);
    }

    public bool DeleteStorage(string path)
    {
        return true;
    }
}