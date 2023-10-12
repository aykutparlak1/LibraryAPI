using LibraryAPI.Application.Repositories.BookRepositories.BookAuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Application.Services.WriteServices.AuthorWriteServices;
using LibraryAPI.Application.Services.WriteServices.CategoryWriteServices;
using LibraryAPI.Application.Services.WriteServices.PublisherWriteServices;
using LibraryAPI.Dtos.Resources.BookResources;
using LibraryAPI.Dtos.Views.BookViews;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public class BookWriteManager : IBookWriteService
    {
        private readonly IBookWriteRepository bookWriteRepository;
        private readonly ICategoryWriteService _categoryWriteService;
        private readonly IAuthorWriteService authorWriteService;
        private readonly IPublisherWriteService publisherWriteService;
        private readonly IBookAuthorWriteRepository bookAuthorWriteRepository;
        public Task<ResponseBookDto> AddBook(AddBookDto addBookDto)
        {
            throw new NotImplementedException();


        }
    }
}
