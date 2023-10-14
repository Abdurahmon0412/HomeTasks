using N52_HT1.DataAccess;
using N53_DependancyInjection.Models;
using N53_DependancyInjection.Services.Interfaces;
using System.Linq.Expressions;

namespace N53_DependancyInjection.Services.FoundationServices;

public class BonusService : IBonusService
{
    private readonly IDataContext _dataContext;

    public BonusService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async ValueTask<Bonus> CreateAsync(Bonus bonus)
    {
        var result = await _dataContext.Bonuses.AddAsync(bonus);

        await _dataContext.SaveChangesAsync();

        return result.Entity;
    }

    public IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate)
        => _dataContext.Bonuses.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Bonus> UpdateAsync(Bonus newbonus)
    {
        var found = _dataContext.Bonuses.FirstOrDefault(bonus => bonus.Id == newbonus.Id);

        if (found == null)
            throw new ArgumentNullException(nameof(found));

        found.BonusAmount = newbonus.BonusAmount;

        await _dataContext.SaveChangesAsync();

        return found;
    }
}