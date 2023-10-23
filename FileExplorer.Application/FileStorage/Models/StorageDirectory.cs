namespace FileExplorer.Application.FileStorage.Models;

public class StorageDirectory
{
    public string Name { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public long ItemCount { get; set; } 
}
