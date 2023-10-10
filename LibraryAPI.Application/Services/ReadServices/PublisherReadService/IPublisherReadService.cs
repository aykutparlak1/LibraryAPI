using LibraryAPI.Application.Dtos.Views.PublisherViews;

namespace LibraryAPI.Application.Services.ReadServices.PublisherReadService
{
    public interface IPublisherReadService
    {
        Task<List<ResponsePublisherDto>> GetAllPublisher();
        Task<ResponsePublisherDto> GetPublisherById(int id);
        Task<ResponsePublisherDto> GetPublisherByName(string name);

    }
}
