using Lips.Dto.Clothes;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Clothes
{
    public interface IOrderClotheService : IBaseService<OrderClotheDto>
    {
        List<OrderClotheDto> GetAllUserClothes(long userId, int page, int size, long? clotheTypeId);
        int GetCounterByuserId(long userId, long? clotheTypeId);
        Dictionary<int, int> GetCountByClotheTypeId(long userId, List<int> clotheTypeIds);


    }
}
