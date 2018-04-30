using Lips.Dto.Users;
using Lips.Infrastructure.Bootstrappers;
using Lips.Service.Users;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Lips.Website.Provider
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        private int userId { set; get; }
        private string error { set; get; }
        private string name { set; get; }
        private string surname { set; get; }
        private string token { set; get; }
        public ApplicationOAuthProvider(string publicClientId)
        {
            _publicClientId = publicClientId ?? throw new ArgumentNullException("publicClientId");

        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {   //
            //If wrong user or password then send it as message , copy from register forms a pssword and email
            //move translate results to translate.tables
            //
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            CultureInfo provider = CultureInfo.DefaultThreadCurrentCulture;
            DateTime birth = DateTime.ParseExact(context.Password,"dd-MM-yyyy",null);
            string clientCode = context.UserName;
            IUserService userService = (IUserService)Bootstrapper.container.Resolve(typeof(IUserService), "");
            UserAuthDto user = null;
            try
            {
                user = userService.Login(birth, clientCode);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                
                return;
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.ExternalClientId)));
            claims.Add(new Claim(ClaimTypes.Sid, Convert.ToString(user.Id)));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));

            token = Convert.ToString(user.Token);
            ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, context.Options.AuthenticationType);//DefaultAuthenticationTypes.ApplicationCookie);
                                                                                                          //  ClaimsIdentity cookiesIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);
            AuthenticationProperties properties = new AuthenticationProperties() { IsPersistent = true };
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
            context.Validated(ticket);
            //  context.Request.Context.Authentication.SignIn(cookiesIdentity);

            //}
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
         
           
            if(!String.IsNullOrEmpty(this.token))
            {
                context.Properties.Dictionary.Add("refresh_token", this.token);
            }
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName }
            };
            return new AuthenticationProperties(data);
        }
    }

}