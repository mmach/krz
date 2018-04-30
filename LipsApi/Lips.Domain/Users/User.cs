using Lips.Domain.Bases;
using Lips.Domain.Clothes;
using Lips.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Users
{
    public class User : Base
    {
        public new long Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public long ExternalClientId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid Token { set; get; }
        public int? Gender { set; get; }
        public long? InstitutionId { set; get; }
        public Guid Guid { set; get; }
        public bool IsMailActivate { set; get; }

        public virtual List<OrdersTracking> OrdersTrackings { get; set; }
        public virtual Institution Institution{ get; set; }

        //public virtual List<ClothesTracking> ClothesTracking { set; get; }
    }
}
