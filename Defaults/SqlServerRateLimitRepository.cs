using WebApi.RateLimits.Interfaces;
using WebApi.RateLimits.Models;
using System;

namespace WebApi.RateLimits.Defaults
{
    class SqlServerRateLimitRepository : IRateLimitRepository
    {
        public void Clear()
        {
            throw new NotImplementedException();
        }

        public RateLimit Get(string identifier)
        {
            throw new NotImplementedException();
        }

        public bool Has(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Set(string identifier, RateLimit rate, long? expiry)
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
