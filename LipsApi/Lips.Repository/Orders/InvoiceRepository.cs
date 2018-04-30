using Lips.Domain.Orders;
using Lips.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Repository.Orders
{
    public class InvoiceRepository : BaseRepository<Invoice> , IInvoiceRepository
    {
    }
}
