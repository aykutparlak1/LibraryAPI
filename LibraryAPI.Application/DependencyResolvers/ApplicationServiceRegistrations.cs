using FluentValidation;
using LibraryAPI.Application.Rules;
using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Application.Services.ReadServices.UserReadService;
using LibraryAPI.Application.Services.WriteServices.UserWriteService;
using LibraryAPI.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LibraryAPI.Application.DependencyResolvers
{
    public class ApplicationServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection )
        {
            var asm = Assembly.GetExecutingAssembly();
            serviceCollection.AddAutoMapper(asm);

            serviceCollection.AddValidatorsFromAssembly(asm);

            
            serviceCollection.AddScoped<AuthorBusinessRules>();
            serviceCollection.AddScoped<UserBusinessRules>();
            

            serviceCollection.AddScoped<IUserReadService,UserReadManager>();
            serviceCollection.AddScoped<IUserWriteService, UserWriteManager>();
            serviceCollection.AddScoped<IAuthService, AuthManager>();
        }
    }
}
