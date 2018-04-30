using Lips.Domain.Orders;
using Lips.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Lips.Domain.Clothes;

namespace Lips.Repository.Orders
{
    public class OrderRepository : BaseRepository<Order> , IOrderRepository
    {
        public List<Order> GetByUserId(long id, int page, int size)
        {
            int startingRowNumber = (page - 1) * size;
            var result = Context.Orders.Where(p => p.UserId == id)
                         .Include(p => p.ClothesTracking.Select(m => m.OrderClothes).Select(m =>m.ClotheType))
                         .Include(p => p.OrdersTrackings)
                         .OrderByDescending(p => p.Id)
                         .Skip(startingRowNumber)
                         .Take(size)
                         .ToList();      

            return result.ToList();
        }

        public Order GetOrderDetails(long userId, long orderId)
        {
            var result = Context.Orders.Where(p => p.UserId == userId && p.Id == orderId)              
                        .Include(p => p.OrdersTrackings)
                        .OrderByDescending(p => p.Id)
                        .ToList();

            return result.FirstOrDefault();
        }
    }
}
