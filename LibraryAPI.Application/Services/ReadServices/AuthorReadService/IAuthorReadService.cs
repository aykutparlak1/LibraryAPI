using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Application.Services.ReadServices.AuthorReadService
{
    public interface IAuthorReadService
    {
        Task<Author> GetByIdAsync(int id);
        Task<List<ResponseAuthorDto>> GetAll();

    }
}
