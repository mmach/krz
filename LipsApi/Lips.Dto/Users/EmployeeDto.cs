using Lips.Dto.Bases;
using Lips.Dto.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Users
{
    public class EmployeeDto : BaseDto
    {
        public string Guid { get; set; }
        public string Address { get; set; }

        public virtual List<OrdersTrackingDto> OrdersTrackings { get; set; }
    }
}
