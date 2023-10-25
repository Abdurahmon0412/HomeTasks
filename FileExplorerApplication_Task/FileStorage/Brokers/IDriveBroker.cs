using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerApplication_Task.FileStorage.Brokers;

public interface IDriveBroker
{
    IEnumerable<StorageDrive> Get();
}