using Lips.Domain.Bases;
using Lips.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Clothes
{
    public class OrderClothe : Base
    {
        public string PrimaryId { get; set; }
        
        [ForeignKey("ClotheType")]
        public int ClotheTypeId { get; set; }
        public long UserId { get; set; }
        public string FinishingMethod { get; set; }
        public string WashProcess { get; set; }
        public string Stay { get; set; }
        public string ReturnDate { get; set; }

        public virtual ClotheType ClotheType { get; set; }
        public virtual User User { get; set; }
        public virtual List<ClothesTracking> ClothesTracking { set;get;}
    }
}
