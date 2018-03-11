using WebApi.RateLimits.Interfaces;
using WebApi.RateLimits.Models;
using System;
using WebApi.RateLimits.Defaults.Configuration;

namespace WebApi.RateLimits.Defaults
{
    class SqlServerRateLimitRepository : IRateLimitRepository
    {
        private SqlServerConfiguration _sqlconfig;
        public SqlServerRateLimitRepository(SqlServerConfiguration configuration)
        {
            _sqlconfig = configuration;
        }
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
