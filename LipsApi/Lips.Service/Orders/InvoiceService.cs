using Lips.Domain.Orders;
using Lips.Dto.Orders;
using Lips.Repository.Orders;
using Lips.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lips.Repository;

namespace Lips.Service.Orders
{
    public class InvoiceService : BaseService<InvoiceDto, Invoice>, IInvoiceService
    {
        public InvoiceService(IBaseRepository<Invoice> repository) : base(repository)
        {
        }

        public List<InvoiceDto> GetByUserId(long userId, int page, int size)
        {
            int startingRowNumber = (page - 1) * size;

            var result = ((IInvoiceRepository)Repository)
                        .Where(m=> m.UserId == userId /*&& m.BillingDate >= DateTime.Now.AddYears(-1)*/)
                        .OrderByDescending(p=>p.Id)
                        .Skip(startingRowNumber)
                        .Take(size)
                        .ToList();
            return AutoMapper.Mapper.Map<List<InvoiceDto>>(result);
        }

        public int GetCountByUserId(long userId)
        {
            var result = Repository.Where(p => p.UserId == userId).Count();
            return result;
        }
    }
}
