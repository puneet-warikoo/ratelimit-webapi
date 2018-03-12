using System;
using System.Collections.Generic;

namespace WebApi.RateLimits.Interfaces
{
    public interface IRateLimitRuleConfig
    {
        long MaxRequests { get; set; }
        TimeSpan Expiry { get; set; }
        IDictionary<string, object> Properties { get; set; }
        
    }
}