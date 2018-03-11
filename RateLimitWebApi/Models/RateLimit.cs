using Newtonsoft.Json;
using WebApi.RateLimits.Interfaces;

namespace WebApi.RateLimits.Models
{
    /// <summary>
    /// Container for the storage of the Rate entries
    /// </summary>
    public class RateLimit : IRateLimit
    {
        public long? Expires { get; set; }
        public long Rate { get; set; }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
