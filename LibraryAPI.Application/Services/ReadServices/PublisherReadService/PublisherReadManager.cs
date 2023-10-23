using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
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

        public async Task<List<ResponsePublisherIdAndNameDto>> GetAllPublisher()
        {
            var res = await _publisherReadRepository.GetQuery().Select(p=> new ResponsePublisherIdAndNameDto
            {
                Id =p.Id,
                PublisherName=p.PublisherName
            }).ToListAsync();
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

        public async Task<ResponsePublisherIdAndNameDto> GetPublisherById(int id)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.Id == id).Select(p => new ResponsePublisherIdAndNameDto
            {
                Id = p.Id,
                PublisherName = p.PublisherName
            }).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Publisher not found");
            return res;
        }

        public async Task<ResponsePublisherIdAndNameDto> GetPublisherByName(string name)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.PublisherName==name).Select(p => new ResponsePublisherIdAndNameDto
            {
                Id = p.Id,
                PublisherName = p.PublisherName
            }).SingleOrDefaultAsync();
            if (res == null ) throw new BusinessException("Publisher not found");
            return res;
        }
    }
}
