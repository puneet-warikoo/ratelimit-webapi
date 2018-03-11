namespace WebApi.RateLimits.Interfaces
{
    /// <summary>
    /// Defines the base contract for the data to be stored for the Rate Limits
    /// </summary>
    public interface IRateLimit
    {
        long? Expires { get; set; }
        long Rate { get; set; }
        string Serialize();
    }
}
