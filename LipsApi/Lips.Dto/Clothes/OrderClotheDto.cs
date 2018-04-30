using Lips.Dto.Bases;
using Lips.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Clothes
{
    public class OrderClotheDto : BaseDto
    {
        public string PrimaryId { get; set; }
        public int ClotheTypeId { get; set; }
        public long UserId { get; set; }
        public string FinishingMethod { get; set; }
        public string WashProcess { get; set; }
        public string Stay { get; set; }
        public string ReturnDate { get; set; }


        public ClotheTypeDto ClotheType { get; set; }
        public List<ClothesTrackingDto> ClothesTracking { get; set; }
        public virtual UserDto User { get; set; }
    }
}
