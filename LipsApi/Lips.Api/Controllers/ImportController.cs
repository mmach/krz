using Lips.Service.Import;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lips.Api.Controllers
{
    public class ImportController : BaseController
    {
        public IImportService ImportService { get; set; }

        public ImportController()
        {           
            this.ImportService = new ImportService(
                  ConfigurationManager.ConnectionStrings["BaseContext"].ConnectionString,
                   ConfigurationManager.AppSettings["ftpAddress"],
                   ConfigurationManager.AppSettings["login"],
                   ConfigurationManager.AppSettings["password"],
                   ConfigurationManager.AppSettings["downloadPath"],
                   ConfigurationManager.AppSettings["csvSeparator"]

                );
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetData()
        {
            try
            {
                ImportService.ImportFiles();
                
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
