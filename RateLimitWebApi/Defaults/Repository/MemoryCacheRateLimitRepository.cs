using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using WebApi.RateLimits.Interfaces;
using WebApi.RateLimits.Models;

namespace WebApi.RateLimits.Defaults
{

    class MemoryCacheRateLimitRepository : IRateLimitRepository
    {
        ObjectCache _cache;
        List<string> _cachekeys;
        public MemoryCacheRateLimitRepository()
        {
            _cache = MemoryCache.Default;

        }
        public void Clear()
        {
            foreach (var key in _cachekeys)
                _cache.Remove(key);
            _cachekeys.Clear();
        }

        public RateLimit Get(string identifier)
        {
            if (this.Has(identifier))
                return (RateLimit)_cache[identifier];
            if (_cachekeys.Contains(identifier))
            {
                _cachekeys.Remove(identifier);
            }
            return null;
        }

        public bool Has(string identifier)
        {
            return _cache.Contains(identifier);
        }

        public void Set(string identifier, RateLimit rate, long? expiry)
        {
            if (this.Has(identifier))
            {
                if (expiry == null)
                    _cache.Set(identifier, rate, new CacheItemPolicy());
                else
                    _cache.Set(identifier, rate, new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(Convert.ToInt64(expiry), new TimeSpan(0)) });
            }
            else
            {
                if (expiry == null)
                    _cache.Add(identifier, rate, new CacheItemPolicy());
                else
                    _cache.Add(identifier, rate, new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(Convert.ToInt64(expiry), new TimeSpan(0)) });
            }
            if (!_cachekeys.Contains(identifier))
            {
                _cachekeys.Add(identifier);
            }
        }

        public bool Validate()
        {
            return _cache != null;
        }
    }
}