using Lips.Domain.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Clothes
{
    public class ClotheType : Base
    {
      
        [Key]
        public new int  Id { get; set; }

        public string Name { get; set; }   
        public long ExternalClotheId { get; set; }
        public int ExternalGroupCodeId { get; set; } 
        public string ExternalGroupName { get; set; }
        
        public virtual List<OrderClothe> OrderClothe { set; get; }
    }
}
