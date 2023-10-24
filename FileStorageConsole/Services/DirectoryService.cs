using FileStorageConsole.Interfaces;

namespace FileStorageConsole.Services;

public class DirectoryService : IDirectoryService
{
    public IEnumerable<string> GetDirectories(string path)
        => Directory.EnumerateDirectories(path);

    public IEnumerable<string> GetFiles(string path)
        => Directory.GetFileSystemEntries(path);
}