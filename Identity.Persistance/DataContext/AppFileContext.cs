using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using Identity.Domain.Entities;

namespace Identity.Persistance.DataContext;

public class AppFileContext : FileContext, IDataContext
{
    public AppFileContext(IFileContextOptions<AppFileContext> fileContextOptions) 
        : base(fileContextOptions){ }

    public IFileSet<VerificationCode, Guid> VerificationCodes => Set<VerificationCode, Guid>(nameof(VerificationCodes));

    public IFileSet<User, Guid> Users => Set<User, Guid> (nameof(Users));
}