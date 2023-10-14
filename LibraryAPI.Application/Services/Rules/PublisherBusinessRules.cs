using LibraryAPI.Application.Repositories.BookRepositories.AuthorRepository;
using LibraryAPI.Application.Repositories.BookRepositories.CategoryRepository;
using LibraryAPI.Application.Repositories.BookRepositories.PublisherRepository;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Core.Utilities.Helpers;
using LibraryAPI.Domain.Entities.BookEntites;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.Rules
{
    public class PublisherBusinessRules
    {
        private readonly IPublisherReadRepository _publisherReadRepository;
        public PublisherBusinessRules(IPublisherReadRepository publisherReadRepository)
        {
            _publisherReadRepository = publisherReadRepository;
        }

        public async Task IfPublisherNotExists(int id)
        {
            bool isExists = await _publisherReadRepository.IsExist(x => x.Id == id);
            if (!isExists) throw new BusinessException($"{id}: Not found.");
        }

        public async Task PublisheryAlreadyExits(string publisherName)
        {
            bool isExists = await _publisherReadRepository.IsExist(x => x.PublisherName == publisherName);
            if (isExists) throw new BusinessException($"{publisherName}: Already Exists");
        }
        public async Task<Publisher> PublisheryAlreadyExitsReturnPublisher(string publisherName)
        {
            Publisher isExists = await _publisherReadRepository.GetQuery(x => x.PublisherName == publisherName).SingleOrDefaultAsync();
            return isExists;
        }
    }
}
