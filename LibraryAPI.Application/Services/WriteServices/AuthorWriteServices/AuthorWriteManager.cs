using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;

namespace LibraryAPI.Application.Services.WriteServices.AuthorWriteServices
{
    public class AuthorWriteManager : IAuthorWriteService
    {
        private readonly IAuthorWriteRepository _authorWriteRepository;
        private readonly AuthorBusinessRules _authorBusinessRules;
        private readonly IMapper _mapper;
        public AuthorWriteManager(IMapper mapper, IAuthorWriteRepository authorWriteRepository, AuthorBusinessRules authorBusinessRules)
        {
            _mapper = mapper;
            _authorWriteRepository = authorWriteRepository;
            _authorBusinessRules = authorBusinessRules;
        }
        public async Task<Author> AddAuthor(CreateAuthorDto model)
        {
           model.AuthorName= model.AuthorName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _authorBusinessRules.AuthorAlreadyExits(model.AuthorName);
            Author addAuthor = _mapper.Map<Author>(model);
            Author addedAuthor = await _authorWriteRepository.AddAsync(addAuthor);
            return addedAuthor;
        }
        public async Task DeleteAuthor(Author author)
        {
            await _authorBusinessRules.AuthorShouldExists(author.Id);
            await _authorWriteRepository.Remove(author);
        }
        public async Task<Author> UpdateAuthor(Author author)
        {
            author.AuthorName = author.AuthorName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _authorBusinessRules.AuthorShouldExists(author.Id);
            await _authorBusinessRules.AuthorAlreadyExits(author.AuthorName);
            await _authorWriteRepository.Update(author);
            return author;
        }
    }
}
