using System.Linq.Expressions;

namespace Identity.Application.Foundations;

public interface IEntityBaseService <T>  where T: class 
{
    ValueTask<T> GetByIdAsync(Guid id);

    IQueryable<T> Get(Expression<Func<T, bool>> predicate);

    ValueTask<T> CreateAsync (T entity);

    ValueTask<T> UpdateAsync (T entity);
}