using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.RateLimits.Interfaces
{
    public interface IRateLimitRuleRepository
    {
        IRateLimitRuleConfig GetRuleConfig(string ruleIdentifier);
    }
}
