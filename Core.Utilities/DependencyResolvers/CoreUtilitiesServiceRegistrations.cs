using Core.Utilities.Caching;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.DependencyResolvers
{
    public class CoreUtilitiesServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITokenHelper, JwtHelper>();
            serviceCollection.AddSingleton<ICacheService, CacheManager>();
        }
    }
}
