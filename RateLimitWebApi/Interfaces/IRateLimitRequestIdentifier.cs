namespace WebApi.RateLimits.Interfaces
{
    using System.Net.Http;
    public interface IRateLimitRequestIdentifier
    {
        string GetIdentifier(HttpRequestMessage requestMessage);
    }
}