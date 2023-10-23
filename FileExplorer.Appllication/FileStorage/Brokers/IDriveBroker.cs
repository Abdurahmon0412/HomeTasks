using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.Appllication.FileStorage.Brokers;

public interface IDriveBroker
{
    IEnumerable<StorageDrive> Get();
}
