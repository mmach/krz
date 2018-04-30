using Lips.Dto.Clothes;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Clothes
{
    public interface IClotheTypeService : IBaseService<ClotheTypeDto>
    {
        List<ClotheTypeDto> GetClothesType(long userGuidId);
    }
}
