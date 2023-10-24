using FileStorageConsole.Models;

namespace FileStorageConsole.Interfaces;

public interface ICleanUpService
{
    public ValueTask<List<string>> CleanUpAsync(User user);
}
