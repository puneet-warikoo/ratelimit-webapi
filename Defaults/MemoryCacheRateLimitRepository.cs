using WebApi.RateLimits.Interfaces;
using WebApi.RateLimits.Models;
using System.Runtime.Caching;
namespace WebApi.RateLimits.Defaults
{
    
    class MemoryCacheRateLimitRepository : IRateLimitRepository
    {
        public MemoryCacheRateLimitRepository()
        {

        }
        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public RateLimit Get(string identifier)
        {
            throw new System.NotImplementedException();
        }

        public bool Has(string identifier)
        {
            throw new System.NotImplementedException();
        }

        public void Set(string identifier, RateLimit rate, long? expiry)
        {
            throw new System.NotImplementedException();
        }

        public bool Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}