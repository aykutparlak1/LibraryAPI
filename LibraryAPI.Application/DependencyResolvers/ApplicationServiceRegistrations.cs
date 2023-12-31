﻿using FluentValidation;
using LibraryAPI.Application.Services.AuthService;
using LibraryAPI.Application.Services.ReadServices.AuthorReadService;
using LibraryAPI.Application.Services.ReadServices.BarrowedBookReadService;
using LibraryAPI.Application.Services.ReadServices.BookReadService;
using LibraryAPI.Application.Services.ReadServices.CategoryReadService;
using LibraryAPI.Application.Services.ReadServices.PublisherReadService;
using LibraryAPI.Application.Services.ReadServices.UserReadService;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Application.Services.WriteServices.AuthorWriteServices;
using LibraryAPI.Application.Services.WriteServices.BarrowBookServices;
using LibraryAPI.Application.Services.WriteServices.BookWriteServices;
using LibraryAPI.Application.Services.WriteServices.CategoryWriteServices;
using LibraryAPI.Application.Services.WriteServices.PublisherWriteServices;
using LibraryAPI.Application.Services.WriteServices.UserWriteServices;
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

            
            serviceCollection.AddScoped<AuthorBusinessRules>();
            serviceCollection.AddScoped<UserBusinessRules>();
            serviceCollection.AddScoped<CategoryBusinessRules>();
            serviceCollection.AddScoped<PublisherBusinessRules>();
            serviceCollection.AddScoped<BarrowBookBusinessRules>();
            serviceCollection.AddScoped<BookBusinessRules>();
            

            serviceCollection.AddScoped<IUserReadService,UserReadManager>();
            serviceCollection.AddScoped<IUserWriteService,UserWriteManager>();

            serviceCollection.AddScoped<IBarrowedBookReadService,BarrowedBookReadManager>();
            serviceCollection.AddScoped<IBarrowBookWriteService,BarrowBookWriteManager>();

            serviceCollection.AddScoped<ICategoryReadService,CategoryReadManager>();
            serviceCollection.AddScoped<ICategoryWriteService,CategoryWriteManager>();

            serviceCollection.AddScoped<IPublisherReadService,PublisherReadManager>();
            serviceCollection.AddScoped<IPublisherWriteService,PublisherWriteManager>();

            serviceCollection.AddScoped<IAuthorReadService,AuthorReadManager>();
            serviceCollection.AddScoped<IAuthorWriteService,AuthorWriteManager>();


            serviceCollection.AddScoped<IBookWriteService, BookWriteManager>();
            serviceCollection.AddScoped<IBookReadService, BookReadManager>();


            serviceCollection.AddScoped<IAuthService, AuthManager>();
            
        }
    }
}
