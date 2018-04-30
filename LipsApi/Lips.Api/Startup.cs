using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lips.Api.Startup))]
namespace Lips.Api
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
 


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
