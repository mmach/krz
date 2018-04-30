
using Lips.Infrastructure.Bootstrappers;
using Microsoft.Owin.Security.OAuth;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Lips.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
              config.SuppressDefaultHostAuthentication();
             config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            Bootstrapper.Register(config);
            config.MapHttpAttributeRoutes();
            config.Formatters.JsonFormatter.SupportedMediaTypes
                    .Add(new MediaTypeHeaderValue("application/json"));
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter
           .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
