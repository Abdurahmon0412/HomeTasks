using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerAPI_Task.Models.Dtos;

public interface IStorageItemDto
{
    string Path { get; set; }

    StorageItemType ItemType { get; set; }
}