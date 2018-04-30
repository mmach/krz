using Lips.Dto.Users;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Users
{
    public interface IInstitutionService : IBaseService<InstitutionDto>
    {
        List<InstitutionDto> GetDeep(string name, int page, int size);
        int GetCounter(string name);
    }
}
