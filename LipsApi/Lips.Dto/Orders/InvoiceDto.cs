using Lips.Dto.Bases;
using Lips.Dto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Dto.Orders
{
    public class InvoiceDto : BaseDto
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string BillingData { get; set; }
        public string Price { set; get; }
        public long ExternalInvoiceId { set; get; }
        public string Url { get; set; }
        public long UserId { set; get; }

        public virtual UserDto User { get; set; }
        public virtual OrderDto Order { get; set; }
    }
}
