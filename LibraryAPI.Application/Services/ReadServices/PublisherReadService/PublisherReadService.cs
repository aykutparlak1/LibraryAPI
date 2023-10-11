using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Views.PublisherViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.PublisherReadService
{
    public class PublisherReadManager : IPublisherReadService
    {
        private readonly IPublisherReadRepository _publisherReadRepository;
        public PublisherReadManager(IPublisherReadRepository publisherReadRepository)
        {
            _publisherReadRepository = publisherReadRepository;
        }



        private static ResponsePublisherDto MapToResponsePublisherDto(Publisher publisher)
        {
            return new ResponsePublisherDto
            {
               PublisherName=publisher.PublisherName
            };
        }


        public async Task<List<ResponsePublisherDto>> GetAllPublisher()
        {
            var res = await _publisherReadRepository.GetQuery().Select(publisher=> MapToResponsePublisherDto(publisher)).ToListAsync();
            if (res == null) throw new BusinessException("Publisher not found");
            return res;
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.Id == id).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Publisher not found");
            return res;
        }

        public async Task<Publisher> GetPublisherByName(string name)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.PublisherName==name).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Publisher not found");
            return res;
        }
    }
}
