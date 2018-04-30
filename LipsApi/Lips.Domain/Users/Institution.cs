using Lips.Domain.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Users
{
    public class Institution : Base
    {
        public string Address { get; set; }
        public long ExternalId { get; set; }
        public bool Mo { get; set; }
        public bool Tu { get; set; }
        public bool We { get; set; }
        public bool Th { get; set; }
        public bool Fr { get; set; }
        public bool Sa { get; set; }
        public bool Su { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
