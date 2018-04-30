using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lips.Api.Model
{
    public class ConsumerMessageObject
    {
        public string MustRead { set; get; }
        public string CultureName { set; get; }
        public string Title { set; get; }
        public string PlainText { set; get; }
        public string HtmlText { set; get; }
    }
}