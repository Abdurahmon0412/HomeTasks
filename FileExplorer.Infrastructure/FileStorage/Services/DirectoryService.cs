using FileExplorer.Appllication.Common.Models.Filtering;
using FileExplorer.Appllication.Common.Querying.Extensions;
using FileExplorer.Appllication.FileStorage.Brokers;
using FileExplorer.Appllication.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _directoryBroker;

    public DirectoryService(IDirectoryBroker directoryBroker)
    {
        _directoryBroker = directoryBroker;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions) =>
        _directoryBroker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);

    public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions) =>
        _directoryBroker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        return new ValueTask<StorageDirectory?>(_directoryBroker.GetByPathAsync(directoryPath));

    }

    public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException($"{nameof(directoryPath)}");
        
        var directories = await Task.Run(() => _directoryBroker.GetDirectories(directoryPath).ApplyPagination(paginationOptions).ToList());

        return directories;
    }
}