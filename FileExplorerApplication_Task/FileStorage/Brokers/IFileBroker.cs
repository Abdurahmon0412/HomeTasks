using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerApplication_Task.FileStorage.Brokers;

public interface IFileBroker 
{
    StorageFile GetByPath(string filePath);
}