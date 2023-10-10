using AutoMapper;
using LibraryAPI.Application.Dtos.Resources.AuthorResources;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Rules;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteService
{
    public class AuthorWriteManager : IAuthorWriteService
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;
        private readonly IMapper _mapper;
        public AuthorWriteManager(IMapper mapper,IAuthorWriteRepository authorWriteRepository, AuthorBusinessRules authorBusinessRules)
        {
            _mapper = mapper;
            _authorWriteRepository = authorWriteRepository;
            _authorBusinessRules = authorBusinessRules;
        }
        public async Task<Author> CreateAuthor(CreateAuthorDto model)
        {
            Author addAuthor = _mapper.Map<Author>(model);
            Author addedAuthor = await _authorWriteRepository.AddAsync(addAuthor);
            await _authorWriteRepository.SaveAsync();
            return addedAuthor;
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
