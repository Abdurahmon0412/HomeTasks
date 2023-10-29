using N63_FileStreamWebAPI.Models.Storage;
using N63_FileStreamWebAPI.Services;

namespace N63_FileStreamWebAPI.Interfaces.FileServices;

public interface IFileService
{
    bool UploadAsync(FileStream fileStorage, string path);

    bool Delete (string path);
}