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
    public class ClotheTypeRepository : BaseRepository<ClotheType>, IClotheTypeRepository
    {
        public List<ClotheType> GetAllByUsers(long userId)
        {
            var result = this.Context.ClotheTypes.Where(m => m.OrderClothe.Where(ct => ct.UserId == userId).Any())
                .Distinct()
                .ToList();

            return result;
        }
    }
}
