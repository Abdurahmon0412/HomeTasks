using FileBaseContext.Abstractions.Models.FileSet;
using FileUpload.Models.Entities;

namespace FileUpload.Presentation;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    IFileSet<StorageFile, Guid> StorageFiles { get; }

    ValueTask SaveChangesAsync();
}