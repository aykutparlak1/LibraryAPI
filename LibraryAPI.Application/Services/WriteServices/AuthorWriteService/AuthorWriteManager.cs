using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Rules;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteService
{
    public class AuthorWriteManager : IAuthorWriteService
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;
        public AuthorWriteManager(IAuthorWriteRepository authorWriteRepository, AuthorBusinessRules authorBusinessRules)
        {
            _authorWriteRepository = authorWriteRepository;
            _authorBusinessRules = authorBusinessRules;
        }
        public async Task<Author> CreateAuthor(Author model)
        {
            Author crtdAuthor = await _authorWriteRepository.AddAsync(model);
            await _authorWriteRepository.SaveAsync();
            return crtdAuthor;
        }

        public async Task<Author> RemoveAuthor(Author author)
        {
            await _authorBusinessRules.AuthorShouldExists(author.Id);
            _authorWriteRepository.Remove(author);
            await _authorWriteRepository.SaveAsync();
            return author;
        }
        public async Task<Author> UpdateAuthor(Author author)
        {
            await _authorWriteRepository.Update(author);
            await _authorWriteRepository.SaveAsync();
            return author;
        }
    }
}
