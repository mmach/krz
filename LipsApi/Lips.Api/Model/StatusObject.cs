using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lips.Api.Model
{
    public class StatusObject
    {
        public CodeObject Code { get; set; }
        public CodeObject SubCode { get; set; }
        public DateTime DateTime { get; set; }
    }
}