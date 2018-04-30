using Lips.Domain.Bases;
using Lips.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Users
{
    public class Employee : Base
    {
        public new int Id { set; get; }
        public string Guid { get; set; }
        public string Address { get; set; }

        public virtual List<OrdersTracking> OrdersTrackings { get; set; }
    }
}
