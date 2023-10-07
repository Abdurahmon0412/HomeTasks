using HometaskN48_API.Models;
using System.Linq.Expressions;

namespace HometaskN48_API.Services.Interfaces
{
    public interface IOrderService
    {
        ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<Order> UpdateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default);

        IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);

        ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

        ValueTask<Order> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        ValueTask<Order> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);

        ValueTask<Order> DeleteAsync(Order oder, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
