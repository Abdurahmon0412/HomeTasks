using AutoMapper;
using FileExplorerApplication_Task.FileStorage.Brokers;
using FileExplorerApplication_Task.FileStorage.Models.Storage;

namespace FileExplorerInfraStructure_Task.FileStorage.Brokers;

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