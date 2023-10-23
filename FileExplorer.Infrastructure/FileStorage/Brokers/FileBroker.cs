using AutoMapper;
using FileExplorer.Appllication.FileStorage.Brokers;
using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class FileBroker : IFileBroker
{
    private readonly IMapper _mapper;

    public FileBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public StorageFile GetByPath(string filePath) => _mapper.Map<StorageFile>(filePath);

}