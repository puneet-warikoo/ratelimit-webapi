using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.RateLimits.Interfaces
{
    public interface IRateLimitRuleRepository
    {
        IRateLimitRuleConfig GetRule(string ruleIdentifier);
        void SetRule(string ruleIdentifier, IRateLimitRuleConfig config);
        bool Has(string ruleIdentifier);
        bool Validate();
    }
}
