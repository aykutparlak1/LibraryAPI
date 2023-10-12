using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.Rules
{
    public class CategoryBusinessRules
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        public CategoryBusinessRules(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }
        
        public async Task IfCategoryAlreadyExists(string categoryName)
        {
            StringHelper.ToLowerAndRemoveSpaces(categoryName);
            bool isExists= await _categoryReadRepository.IsExist(x=>x.CategoryName.ToLower().Replace(" ","")==categoryName);
            if (!isExists) throw new BusinessException($"{categoryName}: Already Exists");
        }
        
        public async Task IsCategoryExist(Category category)
        {
            bool isExists = await _categoryReadRepository.IsExist(x => x.Id==category.Id);
            if (!isExists) throw new BusinessException($"{category} \n Category Already Exists");
        }
    }
}
