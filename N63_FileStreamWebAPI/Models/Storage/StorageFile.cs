namespace N63_FileStreamWebAPI.Models.Storage;

public class StorageFile : IStorageEntry
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public Guid UserId { get; set; }

    public string Path { get; set; } = string.Empty;
}