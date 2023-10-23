using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        public CategoryBusinessRules(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }
        
        public async Task IfCategoryNotExists(int id)
        {
            bool isExists= await _categoryReadRepository.IsExist(x=>x.Id==id);
            if (!isExists) throw new BusinessException($"{id}: Not found.");
        }

        public async Task CategoryAlreadyExits(string categoryName)
        {
            bool isExists = await _categoryReadRepository.IsExist(x => x.CategoryName == categoryName);
            if (isExists) throw new BusinessException($"{categoryName}: Already Exists");
        }
        public async Task<Category> IfCategoryExistReturnCategoryOrThrowException(int id)
        {
            Category isExists = await _categoryReadRepository.GetQuery(x => x.Id == id).SingleOrDefaultAsync();
            if (isExists == null) { throw new BusinessException("Category Not Found"); }
            return isExists;
        }
    }
}
