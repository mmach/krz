using Lips.Api.App_Start;
using Lips.Dto.Users;
using Lips.Infrastructure.Automaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lips.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapping.Register();
        }
    }
}
