using N53_DependancyInjection.Models;
using System.Linq.Expressions;

namespace N53_DependancyInjection.Services.Interfaces;

public interface IBonusService
{
    IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate);

    ValueTask<Bonus> CreateAsync(Bonus bonus);
    ValueTask<Bonus> UpdateAsync(Bonus bonus);
}