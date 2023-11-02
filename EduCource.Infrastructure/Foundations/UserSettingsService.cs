using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using EduCource.Persistance.DataContexts;
using System.Linq.Expressions;

namespace EduCource.Infrastructure.Foundations;

public class UserSettingsService : IEntityBaseService<UserSettings>
{
    private readonly AppDbContext _appDbContext;

    public UserSettingsService() => _appDbContext = new AppDbContext();
    
    public async ValueTask<UserSettings> CreateAsync(UserSettings userSettings)
    {
        await _appDbContext.UserSettingses.AddAsync(userSettings);

        await _appDbContext.SaveChangesAsync();

        return userSettings;
    }

    public IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>> predicate)
            => _appDbContext.UserSettingses.Where(predicate.Compile()).AsQueryable();


    public async ValueTask<UserSettings> GetByIdAsync(Guid id)
        => await _appDbContext.UserSettingses.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "UserSettings not found!");

    public async ValueTask<UserSettings> UpdateAsync(UserSettings userSettings)
    {
        var foundUserSettings = await GetByIdAsync(userSettings.Id);

        _appDbContext.UserSettingses.Update(userSettings);

        await _appDbContext.SaveChangesAsync();
        return userSettings;
    }

    public async ValueTask<UserSettings> DeleteAsync(UserSettings userSettings)
    {
        _appDbContext.Remove(userSettings);

        await _appDbContext.SaveChangesAsync();

        return userSettings;
    }
}