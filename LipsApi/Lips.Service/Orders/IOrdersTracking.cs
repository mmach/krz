using Lips.Dto.Orders;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Orders
{
   public  interface IOrdersTrackingService : IBaseService<OrdersTrackingDto>
    {
        List<OrdersTrackingDto> GetByUserId(long id);
        List<OrdersTrackingDto> GetClothesByOrderID(long id);
    }
}
