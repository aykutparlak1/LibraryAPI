using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Services.AuthorService
{
    public interface IAuthorReadService
    {
        Task<List<Author>> GetAll();
        Task<Author> GetById(int id);

    }
}
