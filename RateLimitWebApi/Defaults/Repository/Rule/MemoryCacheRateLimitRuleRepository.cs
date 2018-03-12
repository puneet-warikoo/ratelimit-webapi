using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using WebApi.RateLimits.Interfaces;

namespace WebApi.RateLimits.Defaults.Repository.Rule
{
    class MemoryCacheRateLimitRuleRepository : IRateLimitRuleRepository
    {
        private ObjectCache _cache;
        private List<string> _cachekeys;
        const string CACHE_IDENTIFIER = "Rule-";
        public MemoryCacheRateLimitRuleRepository()
        {
            _cache = MemoryCache.Default;
            _cachekeys = new List<string>();
        }
        public IRateLimitRuleConfig GetRule(string ruleIdentifier)
        {
            if (this.Has(CACHE_IDENTIFIER + ruleIdentifier))
                return (IRateLimitRuleConfig)_cache[CACHE_IDENTIFIER + ruleIdentifier];
            return null;
        }
        public void SetRule(string ruleIdentifier, IRateLimitRuleConfig config)
        {
            if (this.Has(CACHE_IDENTIFIER + ruleIdentifier))
                _cache.Set(CACHE_IDENTIFIER + ruleIdentifier, config, new CacheItemPolicy());
            else
                _cache.Add(CACHE_IDENTIFIER + ruleIdentifier, config, new CacheItemPolicy());
        }

        public bool Has(string ruleIdentifier)
        {
            return _cache.Contains(CACHE_IDENTIFIER + ruleIdentifier);
        }

        public bool Validate()
        {
            return _cache != null;
        }
    }
}
