using Lips.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Orders
{
    public interface IOrdersTrackingRepository : IBaseRepository<OrdersTracking>
    {
        List<OrdersTracking> GetByUserId(long id);
    }
}
