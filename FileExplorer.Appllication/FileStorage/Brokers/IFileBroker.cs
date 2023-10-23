using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.Appllication.FileStorage.Brokers;

public interface IFileBroker
{
    StorageFile GetByPath(string filePath);
}
