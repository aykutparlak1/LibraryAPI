using LibraryAPI.Core.CrossCuttingConcerns.Caching;
using LibraryAPI.Core.CrossCuttingConcerns.Caching.Redis;
using LibraryAPI.Core.Utilities.IoC;
using LibraryAPI.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.Core.Utilities.DependencyResolvers
{
    public class CoreServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ITokenHelper, JwtHelper>();
            serviceCollection.AddSingleton<ICacheService, RedisCacheManager>();
        }
    }
}
