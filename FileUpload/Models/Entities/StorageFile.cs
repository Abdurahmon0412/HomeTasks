using FileBaseContext.Abstractions.Models.Entity;

namespace FileUpload.Models.Entities;

public class StorageFile : IFileSetEntity<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Extension { get; set; } = string.Empty;

    public long Size { get; set; }

    public Guid UserId { get; set; }
}