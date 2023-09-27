using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;





namespace Core.Utilities.Caching
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
       

        public async Task<object> Add(string key, object value , TimeSpan? duration, CancellationToken  cancellationToken)
        {
            TimeSpan slidingExpiration = duration ?? TimeSpan.FromHours(_cacheSettings.SlidingExpiration);
            DistributedCacheEntryOptions cacheOptions = new() { SlidingExpiration = slidingExpiration };
            byte[] serializeData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value, new JsonSerializerSettings{ ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
            await _cache.SetAsync(key, serializeData, cacheOptions, cancellationToken);
            return value;
        }

        public async Task AddCacheKeyToGroup(string key, string cacheGroup, TimeSpan? duration, CancellationToken cancellationToken)
        {
            TimeSpan sldExprt= duration ?? TimeSpan.FromHours(_cacheSettings.SlidingExpiration);
            byte[]? cacheGroupFromCache = await _cache.GetAsync(key: cacheGroup!, cancellationToken);
            HashSet<string> cacheKeysInGroup;
            if (cacheGroupFromCache != null)
            {
                cacheKeysInGroup = JsonConvert.DeserializeObject<HashSet<string>>(Encoding.Default.GetString(cacheGroupFromCache))!;
                if (!cacheKeysInGroup.Contains(key))
                    cacheKeysInGroup.Add(key);
            }
            else
                cacheKeysInGroup = new HashSet<string>(new[] { key });

            byte[]? cacheGroupCacheSlidingExpirationCache = await _cache.GetAsync(key: cacheGroup, cancellationToken);
            int? cacheGroupCacheSlidingExpirationValue = null;
            if (cacheGroupCacheSlidingExpirationCache != null)
                cacheGroupCacheSlidingExpirationValue = Convert.ToInt32(Encoding.Default.GetString(cacheGroupCacheSlidingExpirationCache));
            if (cacheGroupCacheSlidingExpirationValue == null || sldExprt.TotalSeconds > cacheGroupCacheSlidingExpirationValue)
                cacheGroupCacheSlidingExpirationValue = Convert.ToInt32(sldExprt.TotalSeconds);


            byte[] serializeCacheKeysInGroup = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(cacheKeysInGroup));

            DistributedCacheEntryOptions cacheOptions =
                new() { SlidingExpiration = TimeSpan.FromSeconds(Convert.ToDouble(cacheGroupCacheSlidingExpirationValue)) };

            await _cache.SetAsync(key: cacheGroup, serializeCacheKeysInGroup, cacheOptions,cancellationToken);
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken)
        {
            var cchr = await _cache.GetStringAsync(key, cancellationToken);
            if(cchr != null)
            {
                byte[]? cachedResponse = await _cache.GetAsync(key, cancellationToken);
                var res = JsonConvert.DeserializeObject<T>(Encoding.Default.GetString(cachedResponse));
                return res;
            }
            return default;
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
                    await _cache.RemoveAsync(key: cacheGroup , cancellationToken);
                }
            }
        }
    }
}
