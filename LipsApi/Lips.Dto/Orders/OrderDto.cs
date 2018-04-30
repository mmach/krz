using Lips.Dto.Bases;
using Lips.Dto.Clothes;
using Lips.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Orders
{
    public class OrderDto : BaseDto
    {
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        public string Price { get; set; }
        public string WashNumber { set; get; }

        public virtual List<ClothesTrackingDto> ClothesTracking { set; get; }
        public virtual UserDto User { get; set; }
        public virtual List<OrdersTrackingDto> OrdersTrackings { get; set; }
    }
}
