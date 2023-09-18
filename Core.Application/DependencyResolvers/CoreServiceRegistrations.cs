using Core.Pipelines.Authorization;
using Core.Pipelines.Validation;
using Core.Utilities.IoC;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DependencyResolvers
{
    public class CoreServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        }
    }
}
