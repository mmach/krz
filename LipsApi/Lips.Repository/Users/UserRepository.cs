using Lips.Domain.Users;
using Lips.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lips.Repository.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public User GetUserDetail(long userid)
        {
            var result = this.Context.Users.Where(p => p.Id == userid)
                .Include(p => p.Institution).FirstOrDefault();
            return result;

        }
    }
}
