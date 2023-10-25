using AutoMapper;
using FileExplorerApplication_Task.FileStorage.Brokers;
using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerInfraStructure_Task.FileStorage.Brokers;

public class FileBroker : IFileBroker
{
    private readonly IMapper _mapper;

    public FileBroker(IMapper mapper) => _mapper = mapper;

    public StorageFile GetByPath(string filePath) => _mapper.Map<StorageFile>(new FileInfo(filePath));
}
