using Lips.Domain.Orders;
using Lips.Dto.Orders;
using Lips.Repository.Orders;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;

namespace Lips.Service.Orders
{
    public class OrdersTrackingService : BaseService<OrdersTrackingDto, OrdersTracking>, IOrdersTrackingService
    {
        public OrdersTrackingService(IBaseRepository<OrdersTracking> repository) : base(repository)
        {
        }

        public List<OrdersTrackingDto> GetByUserId(long id)
        {
            var result = GetRepository<OrdersTrackingRepository>().GetByUserId(id);
            return AutoMapper.Mapper.Map<List<OrdersTrackingDto>>(result);
        }

        public List<OrdersTrackingDto> GetClothesByOrderID(long id)
        {
            var result = GetRepository<OrdersTrackingRepository>().Where(m=>m.OrderId==id);
            return AutoMapper.Mapper.Map<List<OrdersTrackingDto>>(result);
        }
    }
}
