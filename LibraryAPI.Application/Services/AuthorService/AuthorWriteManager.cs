using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Rules;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.AuthorService
{
    public class AuthorWriteManager : IAuthorWriteService
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;
        public AuthorWriteManager(IAuthorWriteRepository authorWriteService, AuthorBusinessRules authorBusinessRules)
        {
            _authorWriteRepository = authorWriteService;
            _authorBusinessRules = authorBusinessRules;
        }
        public async Task CreateAuthorAsync(Author model)
        {
            await _authorBusinessRules.AuthorAlreadyExits(model);
            await _authorWriteRepository.AddAsync(model);
        }

        public async Task DeleteAuthorAsync(Author author)
        {
            await _authorBusinessRules.AuthorShouldExists(author.Id);
            await _authorWriteRepository.Remove(author);
        }

        public async Task UpdateAuthorAsync(Author author)
        {

             await _authorBusinessRules.AuthorShouldExists(author.Id);
             await _authorWriteRepository.Update(author);
          }
    }
}
