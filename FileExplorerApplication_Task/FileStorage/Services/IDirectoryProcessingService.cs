using FileExplorerApplication_Task.FileStorage.Models.Filtering;
using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerApplication_Task.FileStorage.Services;

public interface IDirectoryProcessingService
{
    ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPaht, StorageDirectoryEntryFilterModel filterModel);
}
