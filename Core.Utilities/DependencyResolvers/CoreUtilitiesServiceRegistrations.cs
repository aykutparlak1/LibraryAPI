using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.DependencyResolvers
{
    public class CoreUtilitiesServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ITokenHelper, JwtHelper>();
        }
    }
}
