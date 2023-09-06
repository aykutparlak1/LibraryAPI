using FluentValidation;
using LibraryAPI.Core.ApplicationPipelines.Validation;
using LibraryAPI.Core.Utilities.IoC;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.DependencyResolvers
{
    public class ApplicationServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
