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



        public async Task<List<ResponseAuthorDto>> GetAllView()
        {
            var authors = await _authorReadRepository.GetQuery().Select(author=> new ResponseAuthorDto
            {
                AuthorName = author.AuthorName
            }).ToListAsync();
            if (authors == null || authors.Count == 0) throw new BusinessException("Author not found.");
            return authors;
        }
        public async Task<List<Author>> GetAll()
        {
            var authors = await _authorReadRepository.GetQuery().ToListAsync();
            if (authors == null || authors.Count == 0) throw new BusinessException("Author not found.");
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
