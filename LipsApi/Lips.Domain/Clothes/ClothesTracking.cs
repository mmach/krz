using Lips.Domain.Bases;
using Lips.Domain.Orders;
using Lips.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Clothes
{
    public class ClothesTracking : Base
    {

        [ForeignKey("Order")]
        public long OrderId { get; set; }

        [ForeignKey("OrderClothes")]
        public long OrderClothesId { get; set; }
        public ClothesTrackingEnum Action { get; set; }
        public string Comment { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public virtual Order Order { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual OrderClothe OrderClothes { get; set; }
    }

}
