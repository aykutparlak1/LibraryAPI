using AutoMapper;
using LibraryAPI.Application.Dtos.Views.AuthorViews;
using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Rules;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.AuthorReadService
{
    public class AuthorReadManager : IAuthorReadService
    {
        private readonly IAuthorReadRepository _authorReadRepository;

        private readonly AuthorBusinessRules _authorBusinessRules;
        public AuthorReadManager(IAuthorReadRepository authorReadRepository ,AuthorBusinessRules authorBusinessRules)
        {
            _authorBusinessRules = authorBusinessRules;

            _authorReadRepository = authorReadRepository;
        }
        public async Task<List<ResponseAuthorDto>> GetAll()
        {
            var authors = await _authorReadRepository.GetQuery().Select(x=> new ResponseAuthorDto { 
                AuthorName = x.AuthorName            
            }).ToListAsync();
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
