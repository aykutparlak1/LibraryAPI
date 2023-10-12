using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepository;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Application.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Persistence.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Persistence.Repositories.BookRepositories.CategoryRepository;
using Microsoft.Extensions.DependencyInjection;
using LibraryAPI.Application.Repositories.UserRepositories.UserOperationClaimRepository;
using LibraryAPI.Application.Repositories.UserRepositories.OperationClaimRepository;
using LibraryAPI.Core.Utilities.IoC;
using LibraryAPI.Persistence.Repositories.BarrowRepositories.BarrowedBookReadRepository;
using LibraryAPI.Persistence.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Persistence.Repositories.UserRepositories.UserRepository;
using LibraryAPI.Persistence.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Persistence.Repositories.UserRepositories.UserOperationClaimRepository;
using LibraryAPI.Persistence.Repositories.UserRepositories.OperationClaimRepository;

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
