using AutoMapper;
using LibraryAPI.Application.Dtos.Views.PublisherViews;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.PublisherReadService
{
    public class PublisherReadManager : IPublisherReadService
    {
        private readonly IPublisherReadRepository _publisherReadRepository;
        private readonly IMapper _mapper;
        public PublisherReadManager(IPublisherReadRepository publisherReadRepository)
        {
            _publisherReadRepository = publisherReadRepository;
        }
        public async Task<List<ResponsePublisherDto>> GetAllPublisher()
        {
            var res = await _publisherReadRepository.GetQuery().ToListAsync();
            if (res == null) throw new BusinessException("Publisher not found");
            List<ResponsePublisherDto> responsePublisher = _mapper.Map<List<ResponsePublisherDto>>(res);
            return responsePublisher;
        }

        public async Task<ResponsePublisherDto> GetPublisherById(int id)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.Id == id).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Publisher not found");
            ResponsePublisherDto responsePublisher = _mapper.Map<ResponsePublisherDto>(res);
            return responsePublisher;
        }

        public async Task<ResponsePublisherDto> GetPublisherByName(string name)
        {
            var res = await _publisherReadRepository.GetQuery(x => x.PublisherName==name).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException("Publisher not found");
            ResponsePublisherDto responsePublisher = _mapper.Map<ResponsePublisherDto>(res);
            return responsePublisher;
        }
    }
}
