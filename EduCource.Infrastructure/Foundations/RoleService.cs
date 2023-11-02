using EduCource.Application.Foundations;
using EduCource.Domain.Entities;
using EduCource.Persistance.DataContexts;
using System.Linq.Expressions;

namespace EduCource.Infrastructure.Foundations;

public class RoleService : IEntityBaseService<Role>
{
    private readonly AppDbContext _appDbContext;

    public RoleService() => _appDbContext = new AppDbContext();
    
    public async ValueTask<Role> CreateAsync(Role role)
    {
        await _appDbContext.Roles.AddAsync(role);

        await _appDbContext.SaveChangesAsync();

        return role;
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>> predicate)
        => _appDbContext.Roles.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<Role> GetByIdAsync(Guid id)
        => await _appDbContext.Roles.FindAsync(id) ??
            throw new ArgumentOutOfRangeException(nameof(id), "Roles not found!");

    public async ValueTask<Role> UpdateAsync(Role role)
    {
        var foundRole = await GetByIdAsync(role.Id);

        foundRole.Name = role.Name;
        foundRole.UserId = role.UserId;
        foundRole.User = role.User;

        _appDbContext.Roles.Update(foundRole);

        await _appDbContext.SaveChangesAsync();
        return foundRole;

    }

    public async ValueTask<Role> DeleteAsync(Role role)
    {
        _appDbContext.Remove(role);

        await _appDbContext.SaveChangesAsync();

        return role;
    }
}