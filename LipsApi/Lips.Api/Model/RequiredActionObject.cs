using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lips.Api.Model
{
    public class RequiredActionObject
    {
        public string RedirectURL { set; get; }
        public string RequestedInformation { set; get; }
        public string Name { set; get; }
        public string TypeDeprecated { set; get; }

    }
}