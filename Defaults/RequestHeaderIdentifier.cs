using System.Net.Http;
using WebApi.RateLimits.Interfaces;

namespace WebApi.RateLimits.Defaults
{
    class RequestHeaderIdentifier : IRateLimitRequestIdentifier
    {
        public string GetIdentifier(HttpRequestMessage requestMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}
