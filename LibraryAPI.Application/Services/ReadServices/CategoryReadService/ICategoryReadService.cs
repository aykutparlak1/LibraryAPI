using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.CategoryViews;

namespace LibraryAPI.Application.Services.ReadServices.CategoryReadService
{
    public interface ICategoryReadService
    {
        Task<List<ResponseCategoryDto>> GetAllCategoryView();
        Task<List<ResponseCategoryIdAndNameDto>> GetAllCategory();

        Task<ResponseCategoryIdAndNameDto> GetCategoryById(int id);
        Task<ResponseCategoryIdAndNameDto> GetCategoryByName(string name);
    }
}
