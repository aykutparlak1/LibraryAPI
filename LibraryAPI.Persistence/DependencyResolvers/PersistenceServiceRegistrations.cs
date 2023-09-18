using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepositories;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepositories;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepositories;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepositories;
using LibraryAPI.Application.Repositories.UserRepositories.CustomerRepositories;
using LibraryAPI.Application.Repositories.UserRepositories.EmployeeRepositories;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepositories;
using LibraryAPI.Persistence.Repositories.BarrowRepositories;
using LibraryAPI.Persistence.Repositories.BookRepositories.AuthorRepositories;
using LibraryAPI.Persistence.Repositories.BookRepositories.BookRepositories;
using LibraryAPI.Persistence.Repositories.BookRepositories.CategoryRepositories;
using LibraryAPI.Persistence.Repositories.BookRepositories.PublisherRepositories;
using LibraryAPI.Persistence.Repositories.UserRepositories.CustomerRepositories;
using LibraryAPI.Persistence.Repositories.UserRepositories.EmployeeRepositories;
using Microsoft.Extensions.DependencyInjection;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Persistence.Repositories.UserRepositories.UserOperationClaimRepositories;
using LibraryAPI.Application.Repositories.UserRepositories.OperationClaimRepositories;
using LibraryAPI.Persistence.Repositories.UserRepositories.OperationClaimRepositories;
using LibraryAPI.Persistence.Repositories.UserRepositories.UserRepositories;
using Core.Utilities.IoC;

namespace LibraryAPI.Persistence.DependencyResolvers
{
    public class PersistenceServiceRegistrations : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            #region BarrowedBook
            serviceCollection.AddScoped<IBarrowedBookReadRepository, BarrowedBookReadRepository>();
            serviceCollection.AddScoped<IBarrowedBookWriteRepository, BarrowedBookWriteRepository>();
            #endregion

            #region Book
            serviceCollection.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
            serviceCollection.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();

            serviceCollection.AddScoped<IBookReadRepository, BookReadRepository>();
            serviceCollection.AddScoped<IBookWriteRepository, BookWriteRepository>();

            serviceCollection.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            serviceCollection.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

            serviceCollection.AddScoped<IPublisherReadRepository, PublisherReadRepository>();
            serviceCollection.AddScoped<IPublisherWriteRepository, PublisherWriteRepository>();
            #endregion

            #region User
            serviceCollection.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            serviceCollection.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            serviceCollection.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
            serviceCollection.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

            serviceCollection.AddScoped<IUserReadRepository, UserReadRepository>();
            serviceCollection.AddScoped<IUserWriteRepository, UserWriteRepository>();
            serviceCollection.AddScoped<IUserOperationClaimReadRepository, UserOperationClaimReadRepository>();
            serviceCollection.AddScoped<IUserOperationClaimWriteRepository, UserOperationClaimWriteRepository>();
            serviceCollection.AddScoped<IOperationClaimReadRepository,  OperationClaimReadRepository>();
            serviceCollection.AddScoped<IOperationClaimWriteRepository, OperationClaimWriteRepository>();

            #endregion
        }
    }
}
