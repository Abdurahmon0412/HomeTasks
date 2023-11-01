using System;
using System.Linq.Expressions;

namespace LIbrary.Application.Foundations;

public interface IEntityBaseService<T> where T : class
{
    ValueTask<T> CreateAsync(T entity);

    ValueTask<T> GetByIdAsync(Guid id);

    IQueryable<T> Get(Expression<Func<T, bool>> predicate);

    ValueTask<T> UpdateAsync(T entity);

    ValueTask<T> DeleteAsync(T entity);
}