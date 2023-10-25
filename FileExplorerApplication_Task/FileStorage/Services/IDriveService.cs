using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerApplication_Task.FileStorage.Services;

public interface IDriveService
{
    ValueTask<IList<StorageDrive>> GetAsync();
}