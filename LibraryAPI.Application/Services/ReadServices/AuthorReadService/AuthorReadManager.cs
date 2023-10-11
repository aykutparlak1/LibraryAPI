using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.AuthorViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.AuthorReadService
{
    public class AuthorReadManager : IAuthorReadService
    {
        private readonly IAuthorReadRepository _authorReadRepository;
        public AuthorReadManager(IAuthorReadRepository authorReadRepository)
        {

            _authorReadRepository = authorReadRepository;
        }


        private static ResponseAuthorDto MapToResponseAuthorDto(Author author)
        {
            return new ResponseAuthorDto
            {
                AuthorName=author.AuthorName
            };
        }

        public async Task<List<ResponseAuthorDto>> GetAll()
        {
            var authors = await _authorReadRepository.GetQuery().Select(author=> MapToResponseAuthorDto(author)).ToListAsync();
            return authors;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var author = await _authorReadRepository.GetAsync(x=>x.Id == id);
            if (author == null) throw new BusinessException("Author not found.");
            return author;
        }
    }
}
