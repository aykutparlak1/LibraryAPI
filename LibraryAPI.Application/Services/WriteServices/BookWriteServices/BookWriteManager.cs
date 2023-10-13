using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.BookAuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Application.Services.ReadServices.AuthorReadService;
using LibraryAPI.Application.Services.ReadServices.CategoryReadService;
using LibraryAPI.Application.Services.ReadServices.PublisherReadService;
using LibraryAPI.Application.Services.WriteServices.AuthorWriteServices;
using LibraryAPI.Application.Services.WriteServices.CategoryWriteServices;
using LibraryAPI.Application.Services.WriteServices.PublisherWriteServices;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;
using LibraryAPI.Dtos.Resources.BookResources;
using LibraryAPI.Dtos.Resources.CategoryResources;
using LibraryAPI.Dtos.Resources.PublisherResources;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public class BookWriteManager : IBookWriteService
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly ICategoryWriteService _categoryWriteService;
        private readonly ICategoryReadService _categoryReadService;
        private readonly IAuthorWriteService _authorWriteService;
        private readonly IAuthorReadService _authorReadService;
        private readonly IPublisherWriteService _publisherWriteService;
        private readonly IPublisherReadService _publisherReadService;
        private readonly IBookAuthorWriteRepository _bookAuthorWriteRepository;
        
        
        public BookWriteManager(IBookWriteRepository bookWriteRepository,
                                IAuthorReadService authorReadService,IAuthorWriteService authorWriteService,IBookAuthorWriteRepository bookAuthorWriteRepository,
                                ICategoryReadService categoryReadService,ICategoryWriteService categoryWriteService,
                                IPublisherWriteService publisherWriteService,IPublisherReadService publisherReadService)
        {
            _bookAuthorWriteRepository = bookAuthorWriteRepository;
            _bookWriteRepository = bookWriteRepository;
            _authorWriteService = authorWriteService;
             _authorReadService = authorReadService;
            _categoryWriteService = categoryWriteService;
            _categoryReadService = categoryReadService;
            _publisherWriteService = publisherWriteService;
            _publisherReadService = publisherReadService;
            
        }
        //[TransactionScopeAspect]
        public async Task AddBook(AddBookDto addBookDto)
        {
            Book book = new();
           var category = await _categoryReadService.GetCategoryByName(addBookDto.CategoryName);
            if (category == null)
            {
                AddCategoryDto addCategoryDto = new() { CategoryName=addBookDto.CategoryName};
                var addedCategory = await _categoryWriteService.AddCategory(addCategoryDto);
                book.CategoryId = addedCategory.Id;
            }
            else
            {
                book.CategoryId = category.Id;
            }
            var publisher = await _publisherReadService.GetPublisherByName(addBookDto.PublisherName);
            if (publisher == null)
            {
                AddPublisherDto addPublisherDto = new() {PublisherName=addBookDto.PublisherName};
                var addedPublisher = await _publisherWriteService.AddPublisher(addPublisherDto);
                book.PublisherId = addedPublisher.Id;
            }
            else
            {
                book.PublisherId = publisher.Id;
            }

            book.NumberOfPages = addBookDto.NumberOfPages;
            book.Location= addBookDto.Location;
            book.BookName = addBookDto.BookName;

            var addedBook = await _bookWriteRepository.AddAsync(book);

            List<BookAuthor> bookAuthor=new List<BookAuthor>();
            foreach(var item in addBookDto.Authors)
            {
                var author = await _authorReadService.GetAuthorByNameAsync(item.AuthorName);
                if (author == null)
                {

                    CreateAuthorDto createAuthorDto = new() { AuthorName=item.AuthorName };
                    var addedAuthor = await _authorWriteService.AddAuthor(createAuthorDto);
                    bookAuthor.Add(new BookAuthor { BookId= addedBook.Id, AuthorId=addedAuthor.Id});
                }
                else
                {
                    bookAuthor.Add(new BookAuthor { BookId = addedBook.Id, AuthorId = author.Id });
                }
            }
            
            await _bookAuthorWriteRepository.Table.AddRangeAsync(bookAuthor);
            await _bookAuthorWriteRepository.SaveAsync();
        }
    }
}
