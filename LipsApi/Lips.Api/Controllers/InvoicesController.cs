using Lips.Service.Clothes;
using Lips.Service.Orders;
using Lips.Service.Users;
//using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lips.Api.Controllers
{
    public class InvoicesController : BaseController
    {
        public IInvoiceService InvoiceService { get; set; }
        
        public IUserService UserService { get; set; }

        public InvoicesController(IUserService userService, IInvoiceService invoiceService)
        {
            this.UserService = userService;
            this.InvoiceService = invoiceService;
        }

        [Authorize]
        public async Task<IHttpActionResult> GetInvoicesByUserGuid( int page, int size)
        {
            try
            {
                var user = UserService.GetByGuid(userGuidId);
                var result = InvoiceService.GetByUserId(user.Id, page, size);
                var counter = InvoiceService.GetCountByUserId(user.Id);
                return Ok(new
                {
                    Items = result,
                    Counter = counter
                });
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
