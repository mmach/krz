using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Domain.Users;

namespace Lips.Repository.Users
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserDetail(long userid);
    }
}
