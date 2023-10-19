namespace FileStorogeN56.Interfaces;

public interface IFileService
{
    string GetFileExtentions (string filePath);

    long GetFileSize (string filePath);

    bool DeleteFile (string filePath);
}