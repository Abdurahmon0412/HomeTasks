using HometaskN48_API.Models;

namespace HometaskN48_API.Services.Interfaces
{
    public interface IUserOrders
    {
        public IQueryable<Order> GetUserOrders(Guid userId);
    }
}
