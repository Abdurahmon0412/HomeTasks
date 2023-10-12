using FileBaseContext.Abstractions.Models.FileSet;
using HomeTask52_Events.Models;

namespace N52_HT1.DataAccess;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    ValueTask SaveChangesAsync();
}