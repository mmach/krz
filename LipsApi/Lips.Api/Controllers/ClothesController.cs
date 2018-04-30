using Lips.Domain.Clothes;
using Lips.Service.Clothes;
using Lips.Service.Users;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lips.Api.Controllers
{

    public class ClothesController : BaseController
    {
    
        public IClothesTrackingService ClothesTrackingService { get; set; }
        public IClotheTypeService ClothesTypeService { get; set; }
        public IOrderClotheService OrderClotheService { set; get; }
        public IUserService UserService { get; set; }

        public ClothesController(IClothesTrackingService clothesTrackingService, IClotheTypeService  clotheService, IOrderClotheService orderClotheService, IUserService userService)
        {
            this.ClothesTypeService = clotheService;
            this.ClothesTrackingService = clothesTrackingService;
            this.OrderClotheService = orderClotheService;
            this.UserService = userService;
        }


        [Authorize]
        [HttpGet]
        public async Task<IHttpActionResult> GetClothesByUserId(ClothesTrackingEnum  clotheStatus)
        {
            try
            {
                var result = ClothesTrackingService.GetByUserGuidId(userGuidId, clotheStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize]
        [HttpGet]
        public async Task<IHttpActionResult> GetClothesById(string id)
        {
            try
            {
                var result = ClothesTrackingService.GetClothesById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IHttpActionResult> GetClothesType()
        {
            try
            {
                var result = ClothesTypeService.GetClothesType(userGuidId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        [Authorize]
        public async Task<IHttpActionResult> GetAllUserClothes( int page, int size, long? clotheTypeId = null)
        {
            try
            {
                var user = UserService.GetByGuid(userGuidId);

                var result = OrderClotheService.GetAllUserClothes(user.Id, page, size, clotheTypeId);
                var counter = OrderClotheService.GetCounterByuserId(user.Id, clotheTypeId);

                return Ok(new
                {
                    Items = result,
                    Counter = counter
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
        [HttpGet]
        [Authorize]
        public async Task<IHttpActionResult> GetClotheHistory( long clotheId,int page, int size)
        {
            try
            {
                var result = this.ClothesTrackingService.GetClotheHistory(userGuidId, clotheId, page, size);
                var counter = ClothesTrackingService.GetCounterOfHistory(clotheId);
                return Ok(new
                {
                    Items = result,
                    Counter = counter
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }


}
