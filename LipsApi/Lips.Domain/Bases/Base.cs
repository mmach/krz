using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Bases
{
    public abstract class Base
    {
        [Key]
        public virtual long Id { get; set; }

    }
}
