using Lips.Domain.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Clothes
{
    public interface IClothesTrackingRepository : IBaseRepository<ClothesTracking>
    {
        List<ClothesTracking> GetDeepByUserId(long userId,ClothesTrackingEnum clotheStatus);
        List<ClothesTracking> GetClotheHistory(long userId, long clotheId, int page, int size);
        List<ClothesTracking> GetClothesByOrderId(long userId, long orderId);
        int GetCounterOfHistory(long clotheId);
    }
}
