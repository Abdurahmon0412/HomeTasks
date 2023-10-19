using FileStorogeN56.Interfaces;

namespace FileStorogeN56.Services;

public class FileService : IFileService
{
    public bool DeleteFile(string filePath)
    {
        if(File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }
        return false;
    }

    public string GetFileExtentions(string filePath)
        => Path.GetExtension(filePath).Trim();

    public long GetFileSize(string filePath)
        => new FileInfo(filePath).Length;
}