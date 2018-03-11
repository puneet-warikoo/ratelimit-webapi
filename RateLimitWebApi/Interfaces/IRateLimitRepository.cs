using WebApi.RateLimits.Models;

namespace WebApi.RateLimits.Interfaces
{
    /// <summary>
    /// Defines the methods for a interface to act as Rate Limt Repository should act
    /// </summary>
    public interface IRateLimitRepository
    {
        RateLimit Get(string identifier);
        void Clear();
        bool Has(string identifier);
        void Set(string identifier, RateLimit rate, long? expiry);
        bool Validate();
    }
}
