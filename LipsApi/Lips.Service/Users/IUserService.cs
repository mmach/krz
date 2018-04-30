using Lips.Dto.Users;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Users
{
    public interface IUserService : IBaseService<UserDto>
    {
        UserDto GetByGuid(long guid);
        UserAuthDto Login(DateTime dateTime,  string clientCode);
        UserDto GetByToken(string token);
        UserDto GetUserDetail(long userid);
    }
}
