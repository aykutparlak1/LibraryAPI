using FluentValidation;
using LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService;
using LibraryAPI.Application.Services.ReadServices.BookReadService;
using LibraryAPI.Application.Services.ReadServices.UserReadService;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Application.Services.WriteServices.BookWriteServices;
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
            serviceCollection.AddScoped<IBookReadService,BookReadManager>();
            serviceCollection.AddScoped<IBarrowedBookReadService,BarrowedBookReadManager>();


            serviceCollection.AddScoped<IBookWriteService, BookWriteManager>();
            
        }
    }
}
