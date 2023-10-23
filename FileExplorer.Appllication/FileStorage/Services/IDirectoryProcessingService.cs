using FileExplorer.Appllication.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;

namespace Training.FileExplorer.Application.FileStorage.Services;

public interface IDirectoryProcessingService
{
    ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel);
}