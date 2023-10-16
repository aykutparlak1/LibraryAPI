using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.BookAuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.BookResources;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public class BookWriteManager : IBookWriteService
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookAuthorWriteRepository _bookAuthorWriteRepository;

        private readonly BookBusinessRules _bookBusinessRules;

        private readonly IMapper _mapper;
        
        
        public BookWriteManager(IBookWriteRepository bookWriteRepository,
                                IBookAuthorWriteRepository bookAuthorWriteRepository,
                                BookBusinessRules bookBusinessRules, IMapper mapper)
        {
            _bookBusinessRules = bookBusinessRules;
            _bookAuthorWriteRepository = bookAuthorWriteRepository;
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
            
        }
        //[TransactionScopeAspect]
        public async Task<Book> AddBook(AddBookDto addBookDto)
        {
         
                Book mappBook = _mapper.Map<Book>(addBookDto);
                var addedBook = await _bookWriteRepository.AddAsync(mappBook);
                List<BookAuthor> bookAuthors = new();
                foreach (var item in addBookDto.Authors)
                {
                    bookAuthors.Add(new BookAuthor { BookId = addedBook.Id, AuthorId = item.AuthorId });
                }
                await _bookAuthorWriteRepository.AddRange(bookAuthors);
                await _bookAuthorWriteRepository.SaveAsync();
            return addedBook;
        }

        public async Task<Book> UpdateBook(UpdateBookDto updateBookDto)
        {
            Book mappedBook = _mapper.Map<Book>(updateBookDto);
           var result =  _bookWriteRepository.Update(mappedBook);
            List<BookAuthor> bookAuthors=new();
            foreach (var item in updateBookDto.Authors)
            {
                bookAuthors.Add(new BookAuthor { BookId = mappedBook.Id ,AuthorId=item.AuthorId   });
            }
             _bookAuthorWriteRepository.UpdateRange(bookAuthors);
            await _bookAuthorWriteRepository.SaveAsync();
            return result;
        }
        public async Task<Book> DeleteBook(Book book)
        {
            var getBook = _bookBusinessRules.IfBookAlreadyExistsReturnBookElseThrowException(book.Id);
            var result = _bookWriteRepository.Remove(book);
            await _bookWriteRepository.SaveAsync();
            return result;
        }


    }
}
