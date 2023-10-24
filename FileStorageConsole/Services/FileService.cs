using FileStorageConsole.Interfaces;

namespace FileStorageConsole.Services;

public class FileService : IFileService
{
    public string GetFilesExtentions(string filePath)
        => Path.GetExtension(filePath).Trim();
   
    public long GetFileSize(string filePath)
        => new FileInfo(filePath).Length;

    public bool DeleteFile(string filePath)
    {
        if(File.Exists(filePath))
        {
            File.Delete(filePath);
            return true;
        }
        return false;
    }
}