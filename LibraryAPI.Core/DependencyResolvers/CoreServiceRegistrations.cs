using LibraryAPI.Core.Utilities.IoC;
using LibraryAPI.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
namespace LibraryAPI.Core.DependencyResolvers
{
    public class CoreServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddScoped<ITokenHelper, JwtHelper>();
        }
    }
}
