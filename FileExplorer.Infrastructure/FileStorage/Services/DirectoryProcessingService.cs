using FileExplorer.Appllication.FileStorage.Brokers;
using FileExplorer.Appllication.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Models.Filtering;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DirectoryProcessingService : IDirectoryProcessingService
{
    private readonly IDirectoryService _directoryService;
    private readonly IFileService _fileService;

    public DirectoryProcessingService(IFileService fileService, IDirectoryService directoryService)
    {
        _directoryService = directoryService;
        _fileService = fileService;
    }

    public async ValueTask<List<IStorageEntry>> GetEntriesAsync(string directoryPath, StorageDirectoryEntryFilterModel filterModel)
    {
        var storageItems = new List<IStorageEntry>();

        if (filterModel.IncludeDirectories)
            storageItems.AddRange(await _directoryService.GetDirectoriesAsync(directoryPath, filterModel));

        if(filterModel.IncludeFiles)
            storageItems.AddRange(await _fileService.GetFilesByPathAsync(_directoryService.GetFilesPath(directoryPath, filterModel)));

        return storageItems;
    }
}