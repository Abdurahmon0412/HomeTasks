#pragma warning disable CS8618
namespace EduCource.Domain.Entities;

public class Location
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public LocationType Type { get; set; }

    public Guid? ParentId { get; set; }

    public virtual ICollection<Location> ChildLocations { get; set;}

    public virtual Location ParentLocation { get; set; }
}