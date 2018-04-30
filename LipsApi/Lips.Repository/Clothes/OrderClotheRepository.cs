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
    public class OrderClotheRepository : BaseRepository<OrderClothe>, IOrderClotheRepository
    {
        public List<OrderClothe> GetAllBytUser(long userId, int page, int size, long? clotheTypeId)
        {
            int startingRowNumber = (page - 1) * size;

            var result = this.Context.OrderClothes.Where(m => m.UserId == userId && ((clotheTypeId.HasValue && m.ClotheTypeId == clotheTypeId.Value) || !clotheTypeId.HasValue)).Distinct()
                   .Include(p => p.ClotheType)
                   .Include(p => p.ClothesTracking)
                   .OrderByDescending(p=>p.Id)
                   .Skip(startingRowNumber)
                   .Take(size)
                   .ToList();

            foreach(var item in result)
            {
                item.ClothesTracking = new List<ClothesTracking>() { item.ClothesTracking.OrderByDescending(m => m.Id).FirstOrDefault() };
                if (item.ClothesTracking[0] == null)
                {
                    item.ClothesTracking = new List<ClothesTracking>();
                }
               
            }
            return result;
        }

        public Dictionary<int, int> GetCountByClotheTypeId(long userId, List<int> clotheTypeIds)
        {
            var group =  Context.OrderClothes
                         .Where(p => p.UserId == userId && clotheTypeIds.Contains(p.ClotheTypeId))
                         .GroupBy(p => p.ClotheTypeId)
                         .Select(g => new { ClotheTypeId = g.Key, Counter = g.Count() });

            Dictionary<int, int> results = new Dictionary<int, int>();
            foreach (var item in group)
            {
                results.Add(item.ClotheTypeId, item.Counter);
            }
 
            return results;
        }
    }
}
