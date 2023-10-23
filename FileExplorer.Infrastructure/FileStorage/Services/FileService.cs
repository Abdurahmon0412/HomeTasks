using FileExplorer.Appllication.FileStorage.Brokers;
using FileExplorer.Appllication.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class FileService : IFileService
{
    private readonly IFileBroker _fileBroker;

    public FileService(IFileBroker fileBroker) => _fileBroker = fileBroker;

    public async ValueTask<IList<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
    {
        var files = await Task.Run(() => { return filesPath.Select(filePath => _fileBroker.GetByPath(filePath)).ToList(); });

        return files;
    }

    public ValueTask<StorageFile> GetFileByPathAsync(string filePath) =>
        !string.IsNullOrWhiteSpace(filePath) 
            ? new ValueTask<StorageFile>(_fileBroker.GetByPath(filePath))
            : throw new ArgumentNullException(nameof(filePath));
}