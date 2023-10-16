using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.CategoryViews;

namespace LibraryAPI.Application.Services.ReadServices.CategoryReadService
{
    public interface ICategoryReadService
    {
        Task<List<ResponseCategoryDto>> GetAllCategoryView();
        Task<List<Category>> GetAllCategory();

        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string name);
    }
}
