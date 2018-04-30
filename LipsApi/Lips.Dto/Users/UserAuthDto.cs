using Lips.Dto.Bases;
using Lips.Dto.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Users
{
   public  class UserAuthDto : BaseDto
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
        public virtual List<OrdersTrackingDto> OrdersTrackings { get; set; }
    }
}
