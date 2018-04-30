using Lips.Service.Clothes;
using Lips.Service.Orders;
using Lips.Service.Users;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lips.Api.Controllers
{
    public class OrdersController : BaseController
    {
        public IOrdersTrackingService OrdersTrackingService { get; set; }
        public IOrderService OrdersService { get; set; }
        public IUserService UserService { get; set; }
        public IClothesTrackingService ClothesTrackingService { get; set; }



        public OrdersController(IUserService userService, IOrdersTrackingService ordersTrackingService, IOrderService ordersService, IClothesTrackingService clothesTrackingService)
        {
            this.OrdersService = ordersService;
            this.UserService = userService;
            this.OrdersTrackingService = ordersTrackingService;
            this.ClothesTrackingService = clothesTrackingService;
        }

        [Authorize]
        public async Task<IHttpActionResult> GetOrdersByUserGuidId(int page, int size)
        {
            try
            {
                var user = UserService.GetByGuid(userGuidId);
                var result = OrdersService.GetByUserId(user.Id, page, size);
                return Ok(new
                {
                    Items = result,
                    Counter = result.Count
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        public async Task<IHttpActionResult> GetOrderDetails( long orderId)
        {
            try
            {
                var user = UserService.GetByGuid(userGuidId);
                var result = new
                {
                    Order = OrdersService.GetOrderDetails(user.Id, orderId),
                    Clothes = ClothesTrackingService.GetClothesByOrderId(orderId, user.Id)
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
