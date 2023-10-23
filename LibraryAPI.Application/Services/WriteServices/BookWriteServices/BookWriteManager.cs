using AutoMapper;
using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.BookRepositories.BookAuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.BookResources;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.WriteServices.BookWriteServices
{
    public class BookWriteManager : IBookWriteService
    {
        private readonly IBookWriteRepository _bookWriteRepository;
        private readonly IBookAuthorWriteRepository _bookAuthorWriteRepository;
        private readonly IBookAuthorReadRepository _bookAuthorReadRepository;

        private readonly BookBusinessRules _bookBusinessRules;

        private readonly IMapper _mapper;
        
        
        public BookWriteManager(IBookWriteRepository bookWriteRepository,
                                IBookAuthorWriteRepository bookAuthorWriteRepository, IBookAuthorReadRepository bookAuthorReadRepository,
                                BookBusinessRules bookBusinessRules, IMapper mapper)
        {
            _bookBusinessRules = bookBusinessRules;
            _bookAuthorWriteRepository = bookAuthorWriteRepository;
            _bookWriteRepository = bookWriteRepository;
            _mapper = mapper;
            _bookAuthorReadRepository = bookAuthorReadRepository;
            
        }
        //[TransactionScopeAspect]
        public async Task<AddBookDto> AddBook(AddBookDto addBookDto)
        {
            await _bookBusinessRules.AuthorPublisherCategoryShouldExists(addBookDto.Authors, addBookDto.CategoryId, addBookDto.PublisherId);
            Book mappBook = _mapper.Map<Book>(addBookDto);
            var addedBook = _bookWriteRepository.Add(mappBook);
            await _bookWriteRepository.SaveAsync();
            AddBookDto mappedAddedBookDto = _mapper.Map<AddBookDto>(addedBook);
            return mappedAddedBookDto;
        }

        public async Task<UpdateBookDto> UpdateBook(UpdateBookDto updateBookDto)
        {

            await _bookBusinessRules.BookShouldExists(updateBookDto.Id);
            await _bookBusinessRules.AuthorPublisherCategoryShouldExists(updateBookDto.Authors,updateBookDto.CategoryId,updateBookDto.PublisherId);

            var authors = await _bookAuthorReadRepository.GetQuery(x => x.BookId == updateBookDto.Id).ToListAsync();
            _bookAuthorWriteRepository.RemoveRange(authors);
            
            Book mappedBook = _mapper.Map<Book>(updateBookDto);
            var updatedBook =  _bookWriteRepository.Update(mappedBook);
            await _bookWriteRepository.SaveAsync();
            UpdateBookDto mappedUpdatedBookDto = _mapper.Map<UpdateBookDto>(updatedBook);
            return mappedUpdatedBookDto;
        }
        public async Task<bool> DeleteBook(int id)
        {
           var result = await _bookBusinessRules.IfBookExistsReturnBookElseThrowException(id);
            bool isRemoved = _bookWriteRepository.Remove(result);
            await _bookWriteRepository.SaveAsync();
            return isRemoved;
        }


    }
}
