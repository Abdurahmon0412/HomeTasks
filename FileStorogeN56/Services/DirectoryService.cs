using FileStorogeN56.Interfaces;

namespace FileStorogeN56.Services;

public class DirectoryService : IDirectoryService
{
    public IEnumerable<string> GetDirectories(string path)
    {
        return Directory.EnumerateDirectories(path);
    }
    
    public IEnumerable<string> GetFiles(string path)
    {
        return Directory.GetFileSystemEntries(path);
    }
}
