namespace FileStorogeN56.Interfaces;

public interface IDirectoryService
{
    IEnumerable<string> GetDirectories(string path);

    IEnumerable<string> GetFiles(string path);
}