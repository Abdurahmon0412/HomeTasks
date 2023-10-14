using HometaskN48_API.Services.Interfaces;
using N52_HT1.DataAccess;
using N53_DependancyInjection.Models;
using System.Linq.Expressions;

namespace N53_DependancyInjection.Services.FoundationServices
{
    public class OrderService : IOrderService
    {
        private readonly IDataContext _dataContext;

        public OrderService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            await _dataContext.Orders.AddAsync(order, cancellationToken);

            if (saveChanges)
                await _dataContext.Orders.SaveChangesAsync();

            return order;
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            return _dataContext.Orders.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var orders = _dataContext.Orders.Where(order => ids.Contains(order.Id));
            return new ValueTask<ICollection<Order>>(orders.ToList());
        }

        public ValueTask<Order?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var order = _dataContext.Orders.FirstOrDefault(order => order.Id == id);
            return new ValueTask<Order?>(order);
        }

        public async ValueTask<Order> UpdateAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundOrder = _dataContext.Orders.FirstOrDefault(searchingOrder => searchingOrder.Id == order.Id);

            if (foundOrder is null)
                throw new InvalidOperationException("User not found");

            foundOrder.Amount = order.Amount;
            foundOrder.UserId = order.UserId;

            await _dataContext.SaveChangesAsync();

            return foundOrder;
        }


        public async ValueTask<Order> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            var foundOrder = await GetByIdAsync(id, cancellationToken);
            if (foundOrder is null)
                throw new InvalidOperationException("User not found");

            await _dataContext.Orders.RemoveAsync(foundOrder, cancellationToken);
            await _dataContext.Orders.SaveChangesAsync();
            return foundOrder;
        }

        public async ValueTask<Order> DeleteAsync(Order order, bool saveChanges = true, CancellationToken cancellationToken = default)
            => await DeleteAsync(order.Id, saveChanges, cancellationToken);

    }
}
