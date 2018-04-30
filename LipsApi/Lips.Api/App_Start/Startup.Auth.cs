using Lips.Website.Provider;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace Lips.Api
{
    public partial class Startup
    {
        //   public static GoogleOAuth2AuthenticationOptions googleAuthOptions { get; private set; }

        static Startup()
        {
            PublicClientId = "self";

            // UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),//, UserManagerFactory),
                AuthorizeEndpointPath = new PathString("/api/Login/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true
            };
        }



        //   public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
         
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),//, UserManagerFactory),
                //  AuthorizeEndpointPath = new PathString("/api/Login/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };

            app.UseOAuthBearerTokens(OAuthOptions);

           
            //   app.UseGoogleAuthentication();



        }
    }
}
