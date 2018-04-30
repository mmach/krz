using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lips.Api.Model
{
    public class ServiceList
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public List<ParameterObject> Parameters { get; set; }
    }
}