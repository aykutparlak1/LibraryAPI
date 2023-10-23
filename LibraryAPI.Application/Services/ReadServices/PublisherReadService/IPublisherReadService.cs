using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.PublisherViews;

namespace LibraryAPI.Application.Services.ReadServices.PublisherReadService
{
    public interface IPublisherReadService
    {
        Task<List<ResponsePublisherIdAndNameDto>> GetAllPublisher();
        Task<ResponsePublisherIdAndNameDto> GetPublisherById(int id);
        Task<ResponsePublisherIdAndNameDto> GetPublisherByName(string name);
        Task<List<ResponsePublisherDto>> GetAllPublisherView();
    }
}
