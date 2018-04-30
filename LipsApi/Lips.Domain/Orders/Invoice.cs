using Lips.Domain.Bases;
using Lips.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Domain.Orders
{
    public class Invoice : Base
    {
        [ForeignKey("Order")]
        public long? OrderId { get; set; }
        public  DateTime Date { get; set; }
        public string BillingData { get; set; }
        public string Url { get; set; }
        public string Price { set; get; }
        public long ExternalInvoiceId { set; get; }

        [ForeignKey("User")]
        public long UserId { set; get; }

        public virtual User User { get; set; }

        public virtual Order Order { get; set; }
    }
}
