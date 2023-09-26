namespace LibraryAPI.Application.Interfaces
{
    public interface ICachableRequest
    {
        string CacheGroup { get; }
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
