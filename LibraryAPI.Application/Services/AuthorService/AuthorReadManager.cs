using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Rules;
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.AuthorService
{
    public class AuthorReadManager : IAuthorReadService
    {
        readonly IAuthorReadRepository _authorReadRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;
        public AuthorReadManager(IAuthorReadRepository authorReadRepository, AuthorBusinessRules authorBusinessRules)
        {
            _authorReadRepository = authorReadRepository;
            _authorBusinessRules = authorBusinessRules;

        }
        public async Task<List<Author>> GetAll()
        {
           var result =  await _authorReadRepository.GetAll().ToListAsync();
             _authorBusinessRules.AuthorShouldExistsWhenRequest(result[0]);
            return result;
        }

        public async Task<Author> GetById(int id)
        {
            var result = await _authorReadRepository.GetAsync(x=>x.Id == id);
            _authorBusinessRules.AuthorShouldExistsWhenRequest(result);
            return result;
        }
    }
}
