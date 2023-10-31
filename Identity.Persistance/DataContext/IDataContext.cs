using FileBaseContext.Abstractions.Models.FileSet;
using Identity.Domain.Entities;

namespace Identity.Persistance.DataContext;

public interface IDataContext
{
    IFileSet<User, Guid> Users { get; }

    IFileSet<VerificationCode, Guid> VerificationCodes { get; }

    ValueTask SaveChangesAsync();
}