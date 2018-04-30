using Lips.Domain.Bases;
using Lips.Domain.Clothes;
using Lips.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Orders
{
    public class Order : Base
    {
      
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comment { get; set; }
        public string Price { get; set; }

        public virtual User User { get; set; }
        public virtual List<OrdersTracking> OrdersTrackings { get; set; }
        public virtual List<ClothesTracking> ClothesTracking { get; set; }
    }
}
