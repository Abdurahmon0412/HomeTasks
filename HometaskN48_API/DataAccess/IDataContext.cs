using FileBaseContext.Abstractions.Models.FileSet;
using HometaskN48_API.Models;

namespace HometaskN48_API.DataAccess
{
    public interface IDataContext
    {
        IFileSet<User, Guid> Users { get; }
        IFileSet<Order, Guid> Orders { get; }    

        ValueTask SaveChangesAsync();
    }
}


