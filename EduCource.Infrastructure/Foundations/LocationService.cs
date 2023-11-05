using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using EduCource.Persistance.DataContexts;
using System.Linq.Expressions;

namespace EduCource.Infrastructure.Foundations;

public class LocationService : IEntityBaseService<Location>
{
    private readonly AppDbContext _appDbContext;

    public LocationService(AppDbContext appDbContext) => _appDbContext = appDbContext; 
    
    public async ValueTask<Location> CreateAsync(Location location)
    {
        await _appDbContext.Locations.AddAsync(location);

        await _appDbContext.SaveChangesAsync();

        return location;
    }

    public IQueryable<Location> Get(Expression<Func<Location, bool>> predicate)
            => _appDbContext.Locations.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Location> GetByIdAsync(Guid id)
        => await _appDbContext.Locations.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "location not found!");

    public async ValueTask<Location> UpdateAsync(Location location)
    {
        var foundLocation = await GetByIdAsync(location.Id);

        foundLocation.ParentLocation = location.ParentLocation;
        foundLocation.ChildLocations = location.ChildLocations;

        await _appDbContext.SaveChangesAsync();

        return foundLocation;
    }

    public ValueTask<Location> DeleteAsync(Location entity)
    {
        throw new NotImplementedException();
    }
}