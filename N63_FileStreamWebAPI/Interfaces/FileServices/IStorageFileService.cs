using N63_FileStreamWebAPI.Models.Storage;

namespace N63_FileStreamWebAPI.Interfaces.FileServices;

public interface IStorageFileService
{
    ValueTask<StorageFile> CreateStorageAsync(string fileName, Guid userId);

    bool DeleteStorage(string path);
}