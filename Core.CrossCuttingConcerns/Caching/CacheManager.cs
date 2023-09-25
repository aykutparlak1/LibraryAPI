using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public class CacheManager : ICacheService
    {
        private readonly IDistributedCache _cache;
        private readonly CacheSettings _cacheSettings;
        public CacheManager(IDistributedCache distributedCache, IConfiguration configuration) 
        {
            _cache = distributedCache;
            _cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>();
        }


        public async Task<object> Add(string key, object value , int duration ,CancellationToken  cancellationToken)
        {
            TimeSpan? drt = TimeSpan.FromHours(duration);
            TimeSpan? slidingExpiration = drt ?? TimeSpan.FromHours(_cacheSettings.Duration);
            DistributedCacheEntryOptions cacheOptions = new() { SlidingExpiration = slidingExpiration };
            byte[] serializeData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value));
            await _cache.SetAsync(key, serializeData, cacheOptions, cancellationToken);
            return value;
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken)
        {
            byte[]? cachedResponse =  await _cache.GetAsync(key, cancellationToken);
            return JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(cachedResponse));
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken)
        {
            await _cache.RemoveAsync(key, cancellationToken);
        }

        public async Task RemoveByGroupAsync(string cacheGroup, CancellationToken cancellationToken)
        {
            if (cacheGroup != null)
            {
            byte[]? cachedGroup = await _cache.GetAsync(cacheGroup, cancellationToken);
                if (cachedGroup != null)
                {
                    HashSet<string> keysInGroup = JsonConvert.DeserializeObject<HashSet<string>>(Encoding.Default.GetString(cachedGroup))!;
                    foreach (string key in keysInGroup)
                    {
                      await _cache.RemoveAsync(key, cancellationToken);
                    }

                    await _cache.RemoveAsync(cacheGroup, cancellationToken);
                    await _cache.RemoveAsync(key: $"{cacheGroup}SlidingExpiration", cancellationToken);
                }
            }
        }
    }
}
