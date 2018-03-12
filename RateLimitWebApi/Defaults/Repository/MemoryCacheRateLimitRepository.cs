using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using WebApi.RateLimits.Interfaces;
using WebApi.RateLimits.Models;

namespace WebApi.RateLimits.Defaults
{

    class MemoryCacheRateLimitRepository : IRateLimitRepository
    {
        private ObjectCache _cache;
        private List<string> _cachekeys;
        const string CACHE_IDENTIFIER = "Rate-";
        public MemoryCacheRateLimitRepository()
        {
            _cache = MemoryCache.Default;
            _cachekeys = new List<string>();

        }
        public void Clear()
        {
            foreach (var key in _cachekeys)
                _cache.Remove(key);
            _cachekeys.Clear();
        }

        public RateLimit Get(string identifier)
        {
            if (this.Has(CACHE_IDENTIFIER + identifier))
                return (RateLimit)_cache[CACHE_IDENTIFIER + identifier];
            if (_cachekeys.Contains(CACHE_IDENTIFIER + identifier))
            {
                _cachekeys.Remove(CACHE_IDENTIFIER + identifier);
            }
            return null;
        }

        public bool Has(string identifier)
        {
            return _cache.Contains(CACHE_IDENTIFIER + identifier);
        }

        public void Set(string identifier, RateLimit rate, long? expiry)
        {
            if (this.Has(CACHE_IDENTIFIER + identifier))
            {
                if (expiry == null)
                    _cache.Set(CACHE_IDENTIFIER + identifier, rate, new CacheItemPolicy());
                else
                    _cache.Set(CACHE_IDENTIFIER + identifier, rate, new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(Convert.ToInt64(expiry), new TimeSpan(0)) });
            }
            else
            {
                if (expiry == null)
                    _cache.Add(CACHE_IDENTIFIER + identifier, rate, new CacheItemPolicy());
                else
                    _cache.Add(CACHE_IDENTIFIER + identifier, rate, new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(Convert.ToInt64(expiry), new TimeSpan(0)) });
            }
            if (!_cachekeys.Contains(CACHE_IDENTIFIER + identifier))
            {
                _cachekeys.Add(CACHE_IDENTIFIER + identifier);
            }
        }

        public bool Validate()
        {
            return _cache != null;
        }
    }
}