using Lips.Dto.Bases;
using Lips.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Orders
{
    public class OrdersTrackingDto : BaseDto
    {
        public long OrderId { get; set; }
        public long UserId { get; set; }
        public int? EmployeeId { get; set; }
        public OrdersTrackingEnumDto Action { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public virtual OrderDto Order { get; set; }
        public virtual UserDto User { get; set; }
        public virtual EmployeeDto Employee { get; set; }
    }
}
