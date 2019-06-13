using System;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;

[assembly: OwinStartup(typeof(IGA.WebAPI.OAuth.AuthStartup))]

namespace IGA.WebAPI.OAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthStartup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            
            var myProvider = new ApiTokenAuth();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/IGAOAuth"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(Convert.ToInt32(ConfigurationManager.AppSettings["OAuthExpiresInDays"].ToString())),
                Provider = myProvider
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            
        }
    }
}
