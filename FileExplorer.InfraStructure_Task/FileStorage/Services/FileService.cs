using FileExplorerApplication_Task.FileStorage.Brokers;
using FileExplorerApplication_Task.FileStorage.Models.Storage;
using FileExplorerApplication_Task.FileStorage.Services;

namespace FileExplorerInfraStructure_Task.FileStorage.Services;

public class FileService : IFileService
{
    private readonly IFileBroker _fileBroker;

    public FileService(IFileBroker fileBroker) => _fileBroker = fileBroker;

    public async ValueTask<List<StorageFile>> GetFilesByPathAsync(IEnumerable<string> filesPath)
    {
        return await Task.Run(() => { return filesPath.Select(filePath => _fileBroker.GetByPath(filePath))
            .ToList(); });
    }

    public ValueTask<StorageFile> GetFileByPathAsync(string filePath) =>
        !string.IsNullOrWhiteSpace(filePath)
            ? new ValueTask<StorageFile>(_fileBroker.GetByPath(filePath))
            : throw new ArgumentNullException(nameof(filePath));
}