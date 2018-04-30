using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lips.Api.Model
{
    public class ServicesRoot
    {
        public string Currency { set; get; }
        public ServicesObject Services { get; set; }
    }
}