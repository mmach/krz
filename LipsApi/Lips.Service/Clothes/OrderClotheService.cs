using Lips.Domain.Clothes;
using Lips.Dto.Clothes;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;
using Lips.Service.Users;
using Lips.Repository.Clothes;

namespace Lips.Service.Clothes
{
    public class OrderClotheService : BaseService<OrderClotheDto, OrderClothe>, IOrderClotheService
    {
        public IUserService UserService { get; set; }
        public OrderClotheService(IUserService  userService, IBaseRepository<OrderClothe> repository) : base(repository)
        {
            this.UserService = userService;
        }

        public List<OrderClotheDto> GetAllUserClothes(long userId, int page, int size, long? clotheTypeId)
        {          

            var result = ((IOrderClotheRepository)Repository).GetAllBytUser(userId, page, size, clotheTypeId);

            return AutoMapper.Mapper.Map<List<OrderClotheDto>>(result);
           
        }

        public int GetCounterByuserId(long userId, long? clotheTypeId)
        {
            var result = Repository.Where(p => p.UserId == userId && ((clotheTypeId.HasValue && p.ClotheTypeId == clotheTypeId) || !clotheTypeId.HasValue)).Count();
            return result;
        }

        public Dictionary<int, int> GetCountByClotheTypeId(long userId, List<int> clotheTypeIds)
        {
            var result = ((IOrderClotheRepository)Repository).GetCountByClotheTypeId(userId, clotheTypeIds);

            return result;
        }
    }
}
