using Lips.Dto.Bases;
using Lips.Dto.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lips.Dto.Users
{
    [XmlRoot]
   public  class UserDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public long ExternalClientId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? Gender { set; get; }
        public long? InstitutionId { set; get; }
        public Guid Guid { set; get; }
        public bool IsMailActivate { set; get; }

        [XmlIgnore]
        public List<OrdersTrackingDto> OrdersTrackings { get; set; }
        [XmlElement("Institution")]
        public InstitutionDto Institution { get; set; }
    }
}
