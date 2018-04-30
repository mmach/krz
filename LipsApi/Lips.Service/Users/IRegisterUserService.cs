using Lips.Dto.Users;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Users
{
    public interface IRegisterUserService : IBaseService<RegisterUserDto>
    {
        RegisterUserDto UpdateById(RegisterUserDto registerUser);
        RegisterUserDto UpdateByGuid(RegisterUserDto registerUser);
        RegisterUserDto UpdateByMandateId(RegisterUserDto registerUser);
    }
}
