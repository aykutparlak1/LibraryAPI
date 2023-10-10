using AutoMapper;
using LibraryAPI.Application.Dtos.Views.CategoryViews;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.CategoryReadService
{
    public class CategoryReadManager : ICategoryReadService
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IMapper _mapper;

        public CategoryReadManager(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
            _mapper = mapper;
        }
        public async Task<List<ResponseCategoryDto>> GetAllCategory()
        {
            var res = await _categoryReadRepository.GetQuery().ToListAsync();
            if (res == null) throw new BusinessException("Category not found.");
            List<ResponseCategoryDto> responseCategories = _mapper.Map<List<ResponseCategoryDto>>(res);
            return responseCategories;
        }

        public async Task<ResponseCategoryDto> GetCategoryById(int id)
        {
            var res = await _categoryReadRepository.GetQuery(x=>x.Id==id).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Category not found.");
            ResponseCategoryDto responseCategories = _mapper.Map<ResponseCategoryDto>(res);
            return responseCategories;
        }

        public async Task<ResponseCategoryDto> GetCategoryByName(string name)
        {
            var res = await _categoryReadRepository.GetQuery(x => x.CategoryName==name).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Category not found.");
            ResponseCategoryDto responseCategories = _mapper.Map<ResponseCategoryDto>(res);
            return responseCategories;
        }
    }
}
