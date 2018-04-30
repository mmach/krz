using Lips.Domain.Users;
using Lips.Dto.Users;
using Lips.Repository;
using Lips.Repository.Users;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Users
{
    public class InstitutionService : BaseService<InstitutionDto, Institution>, IInstitutionService
    {
        public InstitutionService(IBaseRepository<Institution> repository) : base(repository)
        {

        }

        public int GetCounter(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return Repository.GetAll().Count();
            }
            else {
                var result = Repository.Where(p => p.Address.StartsWith(name)).Count();
                return result;
            }
            
        }

        public List<InstitutionDto> GetDeep(string name, int page, int size)
        {
            var result = ((InstitutionRepository)Repository).GetDeep(name, page, size);
            return AutoMapper.Mapper.Map<List<InstitutionDto>>(result);
        }
    }
}
