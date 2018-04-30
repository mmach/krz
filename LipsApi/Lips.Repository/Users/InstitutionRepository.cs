using Lips.Domain.Users;
using Lips.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Users
{
    public class InstitutionRepository : BaseRepository<Institution>, IInstitutionRepository
    {
        public List<Institution> GetDeep(string name, int page, int size)
        {
            int startingRowNumber = (page - 1) * size;

            if (string.IsNullOrWhiteSpace(name))
            {
                var result = this.Context.Institutions           
                  .OrderByDescending(p => p.Id)
                  .Skip(startingRowNumber)
                  .Take(size)
                  .ToList();
                return result;
            }
            else {
                var result = this.Context.Institutions.Where(m => m.Address.StartsWith(name))              
                  .OrderByDescending(p => p.Id)
                  .Skip(startingRowNumber)
                  .Take(size)
                  .ToList();
                return result;
            }

           
        }
    }
}
