using AutoMapper;
using FileExplorer.Appllication.FileStorage.Brokers;
using FileExplorer.Appllication.FileStorage.Models.Storage;

namespace FileExplorer.Infrastructure.FileStorage.Brokers;

public class DriveBroker : IDriveBroker
{
    private readonly IMapper _mapper;

    public DriveBroker(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IEnumerable<StorageDrive> Get()
    {
        return DriveInfo.GetDrives()
            .Select(drive => _mapper.Map<StorageDrive>(drive))
            .AsQueryable();
    }
}