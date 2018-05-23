using Lips.Service.Clothes;
using Lips.Service.Import;
using Lips.Service.Orders;
using Lips.Service.Users;
//using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lips.Api.Controllers
{
    public class InvoicesController : BaseController
    {
        public IInvoiceService InvoiceService { get; set; }
        
        public IUserService UserService { get; set; }
        public IImportService ImportService { get; set; }

        public InvoicesController(IUserService userService, IInvoiceService invoiceService)
        {
            this.UserService = userService;
            this.InvoiceService = invoiceService;
            this.ImportService = new ImportService(
                ConfigurationManager.ConnectionStrings["BaseContext"].ConnectionString,
                 ConfigurationManager.AppSettings["ftpAddress"],
                 ConfigurationManager.AppSettings["login"],
                 ConfigurationManager.AppSettings["password"],
                 ConfigurationManager.AppSettings["downloadPath"],
                 ConfigurationManager.AppSettings["csvSeparator"]

              );
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

        [Authorize]
        public Task<HttpResponseMessage> GetInvoice(int id)
        {
            try
            {
                var user = UserService.GetByGuid(userGuidId);
                var invoice = InvoiceService.Get(id);
                if (invoice.UserId == user.Id)
                {
                    var invoicePDf = ImportService.GetInvoice(invoice.ExternalInvoiceId);
                    var response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(invoicePDf)
                    };
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = id+".pdf";
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                    return Task.FromResult(response);
                }
                else
                {
                   throw new Exception("Invoice not found");
                }
               

            }
            catch (Exception ex)
            {
                HttpError err = new HttpError(ex.Message);
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.BadRequest, err));
            }
        }
    }
}
