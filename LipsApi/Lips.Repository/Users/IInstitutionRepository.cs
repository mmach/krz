using Lips.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Users
{
    public interface IInstitutionRepository : IBaseRepository<Institution>
    {
        List<Institution> GetDeep(string name, int page, int size);
    }
}
