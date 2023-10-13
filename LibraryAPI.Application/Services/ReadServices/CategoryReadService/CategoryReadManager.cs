using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.CategoryViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.CategoryReadService
{
    public class CategoryReadManager : ICategoryReadService
    {
        private readonly ICategoryReadRepository _categoryReadRepository;



        public CategoryReadManager(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }






        public async Task<List<ResponseCategoryDto>> GetAllCategory()
        {
            var res = await _categoryReadRepository.GetQuery().Select(category=> new ResponseCategoryDto
            {
                CategoryName = category.CategoryName
            }).ToListAsync();
            if (res == null) throw new BusinessException("Category not found.");
            return res;
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var res = await _categoryReadRepository.GetQuery(x=>x.Id==id).SingleOrDefaultAsync();
            return res;
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            var res = await _categoryReadRepository.GetQuery(x => x.CategoryName == name).SingleOrDefaultAsync();
            return res;
        }
    }
}
