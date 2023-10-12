using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.PublisherViews;

namespace LibraryAPI.Application.Services.ReadServices.PublisherReadService
{
    public interface IPublisherReadService
    {
        Task<List<ResponsePublisherDto>> GetAllPublisher();
        Task<Publisher> GetPublisherById(int id);
        Task<Publisher> GetPublisherByName(string name);
    }
}
