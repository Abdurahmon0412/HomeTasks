using FileUpload.Models.Entities;
using FileUpload.Presentation;

namespace FileUpload.Services.Foundations;

public class StorageFileService
{
    private readonly IDataContext _context;

    public StorageFileService(IDataContext dataContext) => _context = dataContext;

    public async ValueTask<StorageFile> CreateFileAsync(StorageFile storageFile)
    {
        if (!IsValidFile(storageFile))
            throw new ArgumentException(nameof(storageFile));

        if (!IsUnique(storageFile))
            throw new ArgumentException(nameof(storageFile));

        await _context.StorageFiles.AddAsync(storageFile);
        await _context.SaveChangesAsync();
        
        return storageFile;
    }

    private bool IsUnique(StorageFile storageFile)
        => !_context.StorageFiles.Any(file =>
        file.Name == storageFile.Name
        && file.UserId.Equals(storageFile.UserId));

    private bool IsValidFile(StorageFile storageFile)
        => !string.IsNullOrWhiteSpace(storageFile.Name);
}
