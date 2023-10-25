namespace FileExplorerApplication_Task.FileStorage.Models.Storage;

public interface IStorageEntry
{
    public string Path { get; set; }

    public StorageItemType ItemType { get; set; }
}