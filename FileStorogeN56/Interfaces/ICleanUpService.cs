using FileStorogeN56.Models;

namespace FileStorogeN56.Interfaces;

public interface ICleanUpService
{
    ValueTask<List<string>> CleanUpAsync(User user);

}
