using Lips.Domain.Clothes;
using Lips.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lips.Repository.Clothes
{
    public class ClothesTrackingRepository : BaseRepository<ClothesTracking>, IClothesTrackingRepository
    {
        public List<ClothesTracking> GetDeepByUserId(long userId, ClothesTrackingEnum clotheStatus )
        {
            var result = Context.ClothesTrackings.Where(p => p.OrderClothes.UserId == userId && (int)p.Action == (int)clotheStatus)
                            .Include(p => p.OrderClothes.User)
                            .Include(p => p.OrderClothes.ClotheType);
            return result.ToList();
        }

        public List<ClothesTracking> GetClotheHistory(long userId, long clotheId, int page, int size)
        {
            int startingRowNumber = (page - 1) * size;
            var result = Context.ClothesTrackings.Where(p => p.Order.UserId == userId && p.OrderClothesId == clotheId).OrderByDescending(m=>m.Date)
                .Include(p=>p.Order)
                .OrderByDescending(p => p.Id)
                .Skip(startingRowNumber)
                .Take(size)
                .ToList();

            return result.ToList();
        }

        public int  GetCounterOfHistory(long clotheId)
        {
            return Context.ClothesTrackings.Where(p => p.OrderClothesId == clotheId).ToList().Count;
        }

        public List<ClothesTracking> GetClothesByOrderId(long userId, long orderId)
        {
            var result = Context.ClothesTrackings.Where(m => m.OrderId == orderId && m.OrderClothes.UserId == userId)
                            .Include(m => m.OrderClothes.ClotheType)
                            .ToList();
            return result.ToList();
        }
    }
}
