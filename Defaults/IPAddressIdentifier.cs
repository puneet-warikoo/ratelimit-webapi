using System.Net.Http;
using WebApi.RateLimits.Interfaces;

namespace WebApi.RateLimits.Defaults.RequestIdentification
{
    public class IPAddressIdentifier : IRateLimitRequestIdentifier
    {
        public string GetIdentifier(HttpRequestMessage requestMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}