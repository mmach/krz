using Lips.Service.Clothes;
using Lips.Service.Orders;
using Lips.Service.Users;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lips.Api.Controllers
{
    public class InstitutionsController : BaseController
    {
        public IInstitutionService InstitutionService { get; set; }


        public InstitutionsController(IInstitutionService institutionService)
        {
            this.InstitutionService = institutionService;
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(string name, int page, int size)
        {
            try
            {               
                var result = InstitutionService.GetDeep(name, page, size);
                return Ok(new
                {
                    Items = result,
                    Counter = InstitutionService.GetCounter(name)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      


    }
}
