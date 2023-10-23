using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDriveService
{
    ValueTask<IList<StorageDrive>> GetAsync();
}