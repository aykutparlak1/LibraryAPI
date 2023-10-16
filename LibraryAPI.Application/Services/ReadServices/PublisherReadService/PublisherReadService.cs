using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Helpers;
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

        public async Task<List<Publisher>> GetAllPublisher()
        {
            var res = await _publisherReadRepository.GetQuery().ToListAsync();
            if (res == null || res.Count == 0) throw new BusinessException("Publisher not found");
            return res;
        }

        public async Task<List<ResponsePublisherDto>> GetAllPublisherView()
        {
            var res = await _publisherReadRepository.GetQuery().Select(publisher=> new ResponsePublisherDto
            {
                PublisherName = publisher.PublisherName
            }).ToListAsync();
            if (res == null || res.Count == 0) throw new BusinessException("Publisher not found");
            return res;
        }

        public async Task<Publisher> GetPublisherById(int id)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.Id == id).SingleOrDefaultAsync();
            return res;
        }

        public async Task<Publisher> GetPublisherByName(string name)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.PublisherName==name).SingleOrDefaultAsync();
            return res;
        }

        Task<ResponsePublisherDto> IPublisherReadService.GetAllPublisherView()
        {
            throw new NotImplementedException();
        }
    }
}
