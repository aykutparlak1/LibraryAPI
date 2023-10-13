using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Helpers;
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



        public async Task<List<ResponseAuthorDto>> GetAll()
        {
            var authors = await _authorReadRepository.GetQuery().Select(author=> new ResponseAuthorDto
            {
                AuthorName = author.AuthorName
            }).ToListAsync();
            return authors;
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var author = await _authorReadRepository.GetQuery(x=>x.Id == id).SingleOrDefaultAsync();
            return author;
        }

        public async Task<Author> GetAuthorByNameAsync(string name)
        {
            var author = await _authorReadRepository.GetQuery(x=>x.AuthorName==name).SingleOrDefaultAsync();
            return author;
        }
    }
}
