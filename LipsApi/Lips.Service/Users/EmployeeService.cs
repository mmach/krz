using Lips.Domain.Users;
using Lips.Dto.Users;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;

namespace Lips.Service.Users
{
    public class EmployeeService : BaseService<EmployeeDto, Employee>, IEmployeeService
    {
        public EmployeeService(IBaseRepository<Employee> repository) : base(repository)
        {
        }
    }
}
