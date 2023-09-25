namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken);
        Task<object> Add(string key, object value, int duration, CancellationToken cancellationToken);

        Task RemoveAsync(string key, CancellationToken cancellationToken);

       Task RemoveByGroupAsync(string cacheGroup, CancellationToken cancellationToken);
    }
}
