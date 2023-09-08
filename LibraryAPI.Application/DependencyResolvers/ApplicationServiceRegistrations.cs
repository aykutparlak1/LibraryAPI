using FluentValidation;
using LibraryAPI.Application.Features.AuthorFeatures.Rules;
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
            var asm = Assembly.GetExecutingAssembly();
            serviceCollection.AddAutoMapper(asm);
            serviceCollection.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(asm));

            serviceCollection.AddValidatorsFromAssembly(asm);
            serviceCollection.AddScoped<AuthorBusinessRules>();

            serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        }
    }
}
