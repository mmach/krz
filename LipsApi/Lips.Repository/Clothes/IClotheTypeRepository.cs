using Lips.Domain.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Clothes
{
    public interface IClotheTypeRepository : IBaseRepository<ClotheType>
    {
        List<ClotheType> GetAllByUsers(long userId);
    }
}
