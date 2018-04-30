using Lips.Domain.Clothes;
using Lips.Dto.Clothes;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Clothes
{
    public interface IClothesTrackingService :  IBaseService<ClothesTrackingDto>
    {
        List<ClothesTrackingDto> GetByUserGuidId(long userGuidId,ClothesTrackingEnum clotheStatus);
        List<ClothesTrackingDto> GetClothesById(string id);
        List<ClothesTrackingDto> GetClothesByOrderId(long orderId, long userId);
        List<ClothesTrackingDto> GetClotheHistory(long userGuid, long clotheId, int page, int size);
        int GetCounterOfHistory(long clotheId);
    }
}
