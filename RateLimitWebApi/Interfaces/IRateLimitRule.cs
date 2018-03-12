using System.Net.Http;

namespace WebApi.RateLimits.Interfaces
{
    public interface IRateLimitRule
    {
        IRateLimitRequestIdentifier Identifier { get; set; }
        IRateLimitRepository Repository { get; set; }
        IRateLimitRuleRepository RuleRepository { get; set; }
        bool IsAllowed(HttpRequestMessage request);
        void UpdateRates(HttpRequestMessage request, HttpResponseMessage response);
        void ProcessResponse(HttpResponseMessage response);
    }
}