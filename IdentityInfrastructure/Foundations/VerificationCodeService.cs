using Identity.Application.Foundations;
using Identity.Domain.Entities;
using Identity.Persistance.DataContext;
using System.Linq.Expressions;

namespace Identity.Infrastructure.Foundations;

public class VerificationCodeService : IEntityBaseService<VerificationCode>
{
    private readonly IDataContext _dataContext;

    public VerificationCodeService(IDataContext dataContext) => _dataContext = dataContext;

    public async ValueTask<VerificationCode> GetByIdAsync(Guid id)
            => await _dataContext.VerificationCodes.FindAsync(id) ??
        throw new ArgumentOutOfRangeException(nameof(id), "verification not found!");

    public IQueryable<VerificationCode> Get(Expression<Func<VerificationCode, bool>> predicate)
            => _dataContext.VerificationCodes.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<VerificationCode> CreateAsync(VerificationCode verificationCode)
    {
        await _dataContext.VerificationCodes.AddAsync(verificationCode);
        await _dataContext.SaveChangesAsync();

        return verificationCode;
    }

    public  ValueTask<VerificationCode> UpdateAsync(VerificationCode verificationCode)
        => throw new InvalidOperationException();
}