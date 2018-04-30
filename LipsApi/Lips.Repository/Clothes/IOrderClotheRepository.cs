using Lips.Domain.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Clothes
{
    public interface IOrderClotheRepository : IBaseRepository<OrderClothe>
    {
        List<OrderClothe> GetAllBytUser(long id, int page, int size, long? clotheTypeId);
        Dictionary<int, int> GetCountByClotheTypeId(long userId, List<int> clotheTypeIds);
    }
}
