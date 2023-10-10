using LibraryAPI.Application.Dtos.Views.CategoryViews;

namespace LibraryAPI.Application.Services.ReadServices.CategoryReadService
{
    public interface ICategoryReadService
    {
        Task<List<ResponseCategoryDto>> GetAllCategory();

        Task<ResponseCategoryDto> GetCategoryById(int id);
        Task<ResponseCategoryDto> GetCategoryByName(string name);
    }
}
