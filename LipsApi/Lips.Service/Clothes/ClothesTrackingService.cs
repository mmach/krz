using Lips.Domain.Clothes;
using Lips.Dto.Clothes;
using Lips.Repository.Clothes;
using Lips.Service.Bases;
using Lips.Service.Users;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;

namespace Lips.Service.Clothes
{
    public class ClothesTrackingService : BaseService<ClothesTrackingDto, ClothesTracking>, IClothesTrackingService
    {

        public IUserService UserService { get; set; }

        public ClothesTrackingService(IUserService userService,IBaseRepository<ClothesTracking> repository) : base(repository)
        {
            this.UserService = userService;
        }
        

        public List<ClothesTrackingDto> GetByUserGuidId(long userGuidId,ClothesTrackingEnum clotheStatus)
        {


            var user = UserService.GetByGuid(userGuidId);
            var result = ((IClothesTrackingRepository)Repository).GetDeepByUserId(user.Id, clotheStatus);
            return AutoMapper.Mapper.Map<List<ClothesTrackingDto>>(result);
        }

        public List<ClothesTrackingDto> GetClothesById(string id)
        {
            var results = Repository.Where(p => string.Compare(p.OrderClothes.PrimaryId, id, StringComparison.InvariantCultureIgnoreCase) == 0).OrderByDescending(p => p.Date);
            return AutoMapper.Mapper.Map<List<ClothesTrackingDto>>(results);
        }

        public List<ClothesTrackingDto> GetClothesByOrderId(long orderId, long userId)
        {
            var result = GetRepository<ClothesTrackingRepository>().GetClothesByOrderId(userId, orderId);
            return AutoMapper.Mapper.Map<List<ClothesTrackingDto>>(result); 

        }

        public List<ClothesTrackingDto> GetClotheHistory(long userGuidId, long clotheId, int page, int size)
        {
            var user = UserService.GetByGuid(userGuidId);

            var result = ((IClothesTrackingRepository)Repository).GetClotheHistory(user.Id, clotheId, page, size);
            return AutoMapper.Mapper.Map<List<ClothesTrackingDto>>(result);

        }

        public int GetCounterOfHistory(long clotheId)
        {
            return ((IClothesTrackingRepository)Repository).GetCounterOfHistory( clotheId);
        }
    }
}
