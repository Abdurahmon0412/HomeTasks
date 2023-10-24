namespace FileStorageConsole.Interfaces;

public interface IFileService
{
    string GetFilesExtentions (string filePath);

    long GetFileSize (string filePath);

    bool DeleteFile(string filePath);
}