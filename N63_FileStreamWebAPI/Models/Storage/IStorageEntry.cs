namespace N63_FileStreamWebAPI.Models.Storage;

public interface IStorageEntry
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public Guid UserId {  get; set; }

    public string Path { get; set; }
}