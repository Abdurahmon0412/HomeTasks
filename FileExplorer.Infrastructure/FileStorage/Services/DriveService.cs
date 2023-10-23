using FileExplorer.Appllication.FileStorage.Brokers;
using FileExplorer.Appllication.FileStorage.Models.Storage;
using Training.FileExplorer.Application.FileStorage.Services;

namespace FileExplorer.Infrastructure.FileStorage.Services;

public class DriveService : IDriveService
{
    private readonly IDriveBroker _broker;

    public DriveService(IDriveBroker driveBroker)
    {
        _broker = driveBroker;
    }

    public ValueTask<IList<StorageDrive>> GetAsync() => 
        new ValueTask<IList<StorageDrive>>(_broker.Get().ToList());
}
