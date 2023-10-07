using HometaskN48_API.DataAccess;
using HometaskN48_API.Models;
using HometaskN48_API.Services.Interfaces;

namespace HometaskN48_API.Services
{
    public class UserOrders : IUserOrders
    {
        private readonly IOrderService _orderService;

        public UserOrders(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IQueryable<Order> GetUserOrders(Guid userId)
            => _orderService.Get(order => order.Id.Equals(userId));
    }
}
