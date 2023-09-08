using LibraryAPI.Core.ApplicationPipelines.Validation;
using LibraryAPI.Core.Utilities.IoC;
using LibraryAPI.Core.Utilities.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
