using AutoMapper;
using FileExplorerApplication_Task.Common.Models.Filtering;
using FileExplorerApplication_Task.Common.Querying.Extensions;
using FileExplorerApplication_Task.FileStorage.Brokers;
using FileExplorerApplication_Task.FileStorage.Models.Storage;
using FileExplorerApplication_Task.FileStorage.Services;

namespace FileExplorerInfraStructure_Task.FileStorage.Services;

public class DirectoryService : IDirectoryService
{
    private readonly IDirectoryBroker _broker;
    private readonly IMapper _mapper;

    public DirectoryService(IDirectoryBroker directoryBroker, IMapper mapper)
    {
        _broker = directoryBroker;
        _mapper = mapper;
    }

    public IEnumerable<string> GetDirectoriesPath(string directoryPath, FilterPagination paginationOptions)
        => _broker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);

    public IEnumerable<string> GetFilesPath(string directoryPath, FilterPagination paginationOptions)
        => _broker.GetFilesPath(directoryPath).ApplyPagination(paginationOptions);

    public ValueTask<StorageDirectory?> GetByPathAsync(string directoryPath)
        => string.IsNullOrWhiteSpace(directoryPath) ? throw new ArgumentNullException(nameof(directoryPath))
            : new ValueTask<StorageDirectory?>(_broker.GetByPathAsync(directoryPath));

    public async ValueTask<IList<StorageDirectory>> GetDirectoriesAsync(string directoryPath, FilterPagination paginationOptions)
    {
        if (string.IsNullOrWhiteSpace(directoryPath))
            throw new ArgumentNullException(nameof(directoryPath));

        var directories = await Task.Run(() => _broker.GetDirectories(directoryPath)
        .ApplyPagination(paginationOptions).ToList());

        return directories;
    }
}