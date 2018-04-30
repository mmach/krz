using Lips.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Orders
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        List<Order> GetByUserId(long id, int page, int size);
        Order GetOrderDetails(long userId, long orderId);
    }
}
