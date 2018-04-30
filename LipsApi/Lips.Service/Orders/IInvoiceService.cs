using Lips.Dto.Orders;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lips.Service.Orders
{
    public interface IInvoiceService : IBaseService<InvoiceDto>
    {
        List<InvoiceDto> GetByUserId(long userId, int page, int size);
        int GetCountByUserId(long userId);
    }
}
