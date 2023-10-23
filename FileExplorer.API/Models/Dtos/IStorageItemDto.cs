using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.API.Models.Dtos;

public interface IStorageItemDto
{
    string Path { get; set; }

    StorageItemType ItemType { get; set; }
}
