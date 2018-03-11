using System.Net.Http;

namespace WebApi.RateLimits.Interfaces
{
    public interface IRateLimitRule
    {
        IRateLimitRequestIdentifier Identifier { get; set; }
        IRateLimitRepository Repository { get; set; }
        bool IsAllowed(HttpRequestMessage request, IRateLimitRepository repository);
        void UpdateRates(HttpRequestMessage request, IRateLimitRepository repository, HttpResponseMessage response);
        void ProcessResponse(HttpResponseMessage response);
    }
}