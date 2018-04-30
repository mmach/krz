using Lips.Domain.Users;
using Lips.Dto.Users;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;
using Lips.Repository.Users;

namespace Lips.Service.Users
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        public UserService(IBaseRepository<User> repository) : base(repository)
        {
        }

        public UserDto GetByGuid(long guid)
        {
            var result = Repository.Where(p => p.ExternalClientId == guid  ).FirstOrDefault();
            if (result == null)
                throw new Exception("User has not been found. Incorrect Id - " + guid);

            return AutoMapper.Mapper.Map<UserDto>(result);

        }

        public UserDto GetByToken(string token)
        {

            var guid = Guid.Parse(token);
            var result = Repository.Where(p=>p.Token == guid).FirstOrDefault();
            if (result == null)
                throw new Exception("Wrong token");

            return AutoMapper.Mapper.Map<UserDto>(result);
        }

        public UserDto GetUserDetail(long userid)
        {
            var result = GetRepository<UserRepository>().GetUserDetail(userid);
            return AutoMapper.Mapper.Map<UserDto>(result);
        }

        public UserAuthDto Login(DateTime dateTime, string clientCode)
        {
            long code = 0;
            Int64.TryParse(clientCode, out code);
            var result = Repository.Where(p => p.ExternalClientId == code && p.BirthDate==dateTime).FirstOrDefault();
            if (result == null)
                throw new Exception("User not exist");

            return AutoMapper.Mapper.Map<UserAuthDto>(result);
        }
    }
}
