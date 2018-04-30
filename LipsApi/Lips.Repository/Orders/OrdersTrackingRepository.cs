using Lips.Domain.Orders;
using Lips.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lips.Repository.Orders
{
    public class OrdersTrackingRepository : BaseRepository<OrdersTracking>, IOrdersTrackingRepository
    {
        public List<OrdersTracking> GetByUserId(long id)
        {
            var result = Context.OrdersTrackings.Where(p => p.UserId == id)
                         .Include(p => p.Order)
                         .OrderByDescending(p => p.Id);
            return result.ToList();
        }
    }
}
