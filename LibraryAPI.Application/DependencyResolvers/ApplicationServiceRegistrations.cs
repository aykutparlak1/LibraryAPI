using Core.Utilities.IoC;
using FluentValidation;
using LibraryAPI.Application.Rules;
using LibraryAPI.Application.Services.AuthorService;
using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Application.Services.UserService;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            serviceCollection.AddScoped<UserBusinessRules>();


            serviceCollection.AddScoped<IUserReadService,UserReadManager>();
            serviceCollection.AddScoped<IUserWriteService, UserWriteManager>();
            serviceCollection.AddScoped<IAuthService, AuthManager>();
            serviceCollection.AddScoped<IAuthorReadService, AuthorReadManager>();
            serviceCollection.AddScoped<IAuthorWriteService, AuthorWriteManager>();
        }
    }
}
