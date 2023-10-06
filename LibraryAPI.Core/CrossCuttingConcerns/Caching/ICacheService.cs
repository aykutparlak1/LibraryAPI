namespace LibraryAPI.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken);
        Task<object> Add(string key, object value, TimeSpan? duration, CancellationToken cancellationToken);
        Task AddCacheKeyToGroup(string key, string cahceGroup, TimeSpan? duration, CancellationToken cancellationToken);
        Task RemoveAsync(string key, CancellationToken cancellationToken);
        Task RemoveByGroupAsync(string cacheGroup, CancellationToken cancellationToken);
    }
}
