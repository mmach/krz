using Lips.Dto.Bases;
using Lips.Dto.Orders;
using Lips.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Clothes
{
    public class ClothesTrackingDto : BaseDto
    {
        public long OrderClothesId { get; set; }
        public long OrderId { get; set; }
        public ClothesTrackingEnumDto Action { get; set; }
        public string Comment { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public virtual OrderDto Order { get; set; }
        public virtual EmployeeDto Employee { get; set; }
        public virtual OrderClotheDto OrderClothes { get; set; }
    }
}
