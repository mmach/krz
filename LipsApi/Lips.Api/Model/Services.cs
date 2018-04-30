using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lips.Api.Model
{
  
    public class ServicesObject
    {
        public string Key { get; set; }
        public StatusObject Status { get; set; }
        public RequiredActionObject RequiredAction { get; set; }
        public List<ServiceList> ServiceList { get; set; }
        public List<ServiceList> Services { get; set; }
        public string CustomParameters { get; set; }
        public string AdditionalParameters { get; set; }
        public string RequestErrors { get; set; }
        public string ServiceCode { get; set; }
        public string IsTest { get; set; }
        public ConsumerMessageObject ConsumerMessage { get; set; }

    }
 
    
   
  
    
}