using AutoMapper;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
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
 
            Author mappedAuthor = _mapper.Map<Author>(model);
            Author addedAuthor = await _authorWriteRepository.AddAsync(mappedAuthor);
            await _authorWriteRepository.SaveAsync();
            return addedAuthor;
        }
        public async Task DeleteAuthor(int id)
        {
            await _authorBusinessRules.AuthorShouldExists(id);
            _authorWriteRepository.Remove(author);
            await _authorWriteRepository.SaveAsync();
        }
        public async Task<Author> UpdateAuthor(Author author)
        {
            author.AuthorName = author.AuthorName.UppercaseFirstLetterOfEachWordAndOtherLower();
            await _authorBusinessRules.AuthorShouldExists(author.Id);
            await _authorBusinessRules.AuthorAlreadyExits(author.AuthorName);
            _authorWriteRepository.Update(author);
            await _authorWriteRepository.SaveAsync();
            return author;
        }
    }
}
