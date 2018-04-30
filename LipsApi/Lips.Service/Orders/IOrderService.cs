using Lips.Dto.Orders;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Orders
{
    public interface IOrderService : IBaseService<OrderDto>
    {
        List<OrderDto> GetByUserId(long id, int page, int size);
        OrderDto GetOrderDetails(long userId, long orderId);
    }
}
