using Lips.Domain.Clothes;
using Lips.Dto.Clothes;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;
using Lips.Repository.Clothes;
using Lips.Repository.Users;
using Lips.Service.Users;

namespace Lips.Service.Clothes
{
    public class ClotheTypeService : BaseService<ClotheTypeDto, ClotheType>, IClotheTypeService
    {
        IUserService UserService { set; get; }
        IOrderClotheService OrderClotheService { get; set; }

        public ClotheTypeService(IBaseRepository<ClotheType> repository,IUserService userService, IOrderClotheService orderClotheService) : base(repository)
        {
            UserService = userService;
            OrderClotheService = orderClotheService;
        }
        public List<ClotheTypeDto> GetClothesType(long userGuidId)
        {
            var userId = UserService.GetByGuid(userGuidId); 
            var result = ((IClotheTypeRepository)Repository).GetAllByUsers(userId.Id);
            var resultsDto = AutoMapper.Mapper.Map<List<ClotheTypeDto>>(result);

            var clotheTypes = resultsDto.Select(p => p.Id).ToList();
            var counters = OrderClotheService.GetCountByClotheTypeId(userId.Id, clotheTypes);

            foreach (var item in resultsDto)
            {
                item.Total = counters[item.Id];
            }

            return resultsDto;
        }

      
    }
}
