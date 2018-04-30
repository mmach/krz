

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Lips.Api.Controllers
{
    public class BaseController : ApiController
    {       
        public long userid
        {
            get
            {
                return Convert.ToInt64( ((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
            }
        }
        public long userGuidId
        {
            get
            {
                return Convert.ToInt64(((ClaimsPrincipal)Thread.CurrentPrincipal).Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault());
            }
        }
        public string userName {
            get
            {
                return ((ClaimsIdentity)User.Identity).Name;
            }
        }

       protected override void Initialize(HttpControllerContext controllerContext)
        {
           base.Initialize(controllerContext);
          //  var tmp =(ClaimsPrincipal)Thread.CurrentPrincipal;
           
            
        }

    }
}
