using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApi.RateLimits.Interfaces;
using System;
namespace WebApi.RateLimits.Core
{
    public class RateLimitHandler : DelegatingHandler
    {
        private List<IRateLimitRule> _rules;
        private IRateLimitRepository _repository;
        public RateLimitHandler(List<IRateLimitRule> rules, IRateLimitRepository repository)
        {
            _rules = rules ?? throw new ArgumentNullException("rules");
            _repository = repository ?? throw new ArgumentNullException("repository");
            if (!_repository.Validate())
                throw new ArgumentException("Could not validate the connection to the repository.");
        }
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response = null;
            List<IRateLimitRule> _applied = new List<IRateLimitRule>();
            bool failedPolicy = false;
            foreach (var rule in this._rules)
            {
                _applied.Add(rule);
                if (rule != null && rule.IsAllowed(request))
                {
                    continue;
                }
                else
                {
                    failedPolicy = true;
                    response = new HttpResponseMessage((System.Net.HttpStatusCode)429) { Content = new StringContent("Rate limit exceeded"), RequestMessage = request };
                    break;
                }

            }
            if (!failedPolicy)
                response = await base.SendAsync(request, cancellationToken);

            foreach (var rule in _applied)
            {
                rule.UpdateRates(request, response);
                rule.ProcessResponse(response);
            }
            return response;
        }
    }
}