using Lips.Domain.Orders;
using Lips.Dto.Orders;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;
using Lips.Repository.Orders;
using Lips.Service.Clothes;
using Lips.Dto.Clothes;
using Lips.Domain.Clothes;

namespace Lips.Service.Orders
{
    public class OrderService : BaseService<OrderDto, Order>, IOrderService
    {
        public IOrdersTrackingService  OrdersTrackingService { set; get; }
        public IClothesTrackingService ClotheTrackingService { set; get; }
        public IOrderClotheService OrderClotheService { set; get; }
        public OrderService(IBaseRepository<Order> repository, IOrdersTrackingService OrdersTrackingService, IClothesTrackingService clotheTrackingService, IOrderClotheService orderClotheService) : base(repository)
        {
            this.OrderClotheService = orderClotheService;
            this.OrdersTrackingService = OrdersTrackingService;
            this.ClotheTrackingService = clotheTrackingService;
        }

        public List<OrderDto> GetByUserId(long id, int page, int size)
        {
            var resultEntity = GetRepository<OrderRepository>().GetByUserId(id, page, size);
          

            foreach (var item in resultEntity)
            {
                List<ClothesTracking> cTracking = new List<ClothesTracking>();
                List<long> uniqueIds = new List<long>();

                for (int i = item.ClothesTracking.Count - 1; i >= 0; i--)
                {
                    if (!uniqueIds.Contains(item.ClothesTracking[i].OrderClothesId))
                    {
                        uniqueIds.Add(item.ClothesTracking[i].OrderClothesId);
                        cTracking.Add(item.ClothesTracking[i]);
                    }
                   
                }
                item.ClothesTracking = cTracking;
            }

            var  result = AutoMapper.Mapper.Map<List<OrderDto>>(resultEntity);
     
            return result;       
        }

        public OrderDto GetOrderDetails(long userGuidId, long orderId)
        {
            var result = GetRepository<OrderRepository>().GetOrderDetails(userGuidId, orderId);
            return AutoMapper.Mapper.Map<OrderDto>(result);

        }
    }
    
}
