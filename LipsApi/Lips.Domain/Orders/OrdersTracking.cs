using Lips.Domain.Bases;
using Lips.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Orders
{
    public class OrdersTracking : Base
    {
        [ForeignKey("Order")]
        public long OrderId { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        public int? EmployeeId { get; set; }

        public OrdersTrackingEnum Action { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
