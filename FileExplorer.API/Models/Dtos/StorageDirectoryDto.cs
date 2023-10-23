using Training.FileExplorer.Application.FileStorage.Models.Storage;

namespace FileExplorer.API.Models.Dtos;

public class StorageDirectoryDto
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public long ItemsCount { get; set; }
    public StorageItemType StorageItemType { get; set; }
}
