using FileBaseContext.Abstractions.Models.FileSet;
using N53_DependancyInjection.Models;

namespace N52_HT1.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }
    IFileSet<Order, Guid> Orders { get; }
    IFileSet<Bonus, Guid> Bonuses { get; }
    ValueTask SaveChangesAsync();
}