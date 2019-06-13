using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;


namespace IGA.WebAPI.OAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiTokenAuth : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        //    var validUser = IsUserValid(context.UserName, context.Password);

        //    if (validUser.IsTransactionDone)
        //    {
        //        if(validUser.IsValidUser)
        //        {
        //            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

        //            var userDetails = _user.FetchUserInformation(context.UserName); 
        //            identity.AddClaim(new Claim("userID", userDetails.UserID.ToString()));
        //            identity.AddClaim(new Claim("userName",string.IsNullOrEmpty(userDetails.UserName)?"":userDetails.UserName));
        //            identity.AddClaim(new Claim("profpic", string.IsNullOrEmpty(userDetails.ProfPicURL) ? "" : userDetails.ProfPicURL));
        //            context.Validated(identity);
        //        }
        //        else
        //        {
        //            context.SetError("invalid_grant", "Provided username and password is incorrect");
        //            return base.GrantResourceOwnerCredentials(context);
        //        }
        //    }
        //    else
        //    {
        //        context.SetError("Transaction_error", "Transaction failed. Please try again");
        //        //new Task(() => { TrackLoginAudit(loginAudit); }).Start();
        //        return base.GrantResourceOwnerCredentials(context);
        //    }
        //    return base.GrantResourceOwnerCredentials(context);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key.Remove(0,1), property.Value);
            }

            var identity = context.Identity as ClaimsIdentity;

            var userId = identity.Claims
                       .Where(c => c.Type == "userID")
                       .Select(c => c.Value);

            if (userId != null)
            {
                var userIdKeyValue = new KeyValuePair<string, string>("userID", string.Join(",", userId.ToList()));
                context.AdditionalResponseParameters.Add(userIdKeyValue.Key, userIdKeyValue.Value);
            }
            var username = identity.Claims
                       .Where(c => c.Type == "userName")
                       .Select(c => c.Value);

            if (username != null)
            {
                var userIdKeyValue = new KeyValuePair<string, string>("userName", string.Join(",", username.ToList()));
                context.AdditionalResponseParameters.Add(userIdKeyValue.Key, userIdKeyValue.Value);
            }
            var profpic = identity.Claims
                       .Where(c => c.Type == "profpic")
                       .Select(c => c.Value);

            if (userId != null)
            {
                var userIdKeyValue = new KeyValuePair<string, string>("profpic", string.Join(",", profpic.ToList()));
                context.AdditionalResponseParameters.Add(userIdKeyValue.Key, userIdKeyValue.Value);
            }
            context.AdditionalResponseParameters.Add("statusCode", 200);

            return Task.FromResult<object>(null);
        }

    }
}