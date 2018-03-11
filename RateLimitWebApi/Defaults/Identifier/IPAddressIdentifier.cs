using Microsoft.Owin;
using System.Net.Http;
using System.Web;
using WebApi.RateLimits.Interfaces;

namespace WebApi.RateLimits.Defaults.RequestIdentification
{
    public class IPAddressIdentifier : IRateLimitRequestIdentifier
    {
        public string GetIdentifier(HttpRequestMessage requestMessage)
        {
            if (requestMessage.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)requestMessage.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }

            if (requestMessage.Properties.ContainsKey("MS_OwinContext"))
            {
                OwinContext owinContext = (OwinContext)requestMessage.Properties["MS_OwinContext"];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }

            return null;
        }
    }
}