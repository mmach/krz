using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lips.Api.Model
{
    public class ContactRequestObject
    {
        public string Email { set; get; }

        public string Name { set; get; }

        public string PhoneNumber { set; get; }
        public string Address { set; get; }
        public string Institution { set; get; }
        public string NameAuth { set; get; }
        public long ClientId { set; get; }
    }
}