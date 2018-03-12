using System;
using System.Net.Http;
using WebApi.RateLimits.Interfaces;

namespace RateLimitWebApi.Defaults
{
    class IPAddressRateLimitRule : IRateLimitRule
    {
        public IRateLimitRequestIdentifier Identifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRateLimitRepository Repository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRateLimitRuleRepository RuleRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsAllowed(HttpRequestMessage request, IRateLimitRequestIdentifier requestident, IRateLimitRepository repository)
        {
            throw new NotImplementedException();
        }

        public bool IsAllowed(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }

        public void ProcessResponse(HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }

        public void UpdateRates(HttpRequestMessage request, HttpResponseMessage response)
        {
            throw new NotImplementedException();
        }
    }
}
