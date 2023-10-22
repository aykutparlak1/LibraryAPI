using AutoMapper;
using LibraryAPI.Application.Repositories.BarrowRepositories.BarrowedBookRepository;
using LibraryAPI.Application.Repositories.BookRepositories.BookRepository;
using LibraryAPI.Application.Services.Rules;
using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Dtos.Resources.BarrowBookResources;
using LibraryAPI.Dtos.Views.BarrowedBookViews;

namespace LibraryAPI.Application.Services.WriteServices.BarrowBookServices
{
    public class BarrowBookManager : IBarrowBookService
    {
        private readonly IBarrowedBookWriteRepository _barrowedBookWriteRepository;
        private readonly BarrowBookBusinessRules _barrowBookBusinessRules;
        private readonly IMapper _mapper;


        public BarrowBookManager(IBarrowedBookWriteRepository barrowedBookWriteRepository, BarrowBookBusinessRules barrowBookBusinessRules,IMapper mapper)
        {
            _barrowBookBusinessRules = barrowBookBusinessRules;
            _barrowedBookWriteRepository = barrowedBookWriteRepository;
            _mapper = mapper;
        }


        public async Task<BarrowedBook> AddBarrowedBook(BarrowBookDto barrowBookDto)
        {
            await _barrowBookBusinessRules.BookIsExists(barrowBookDto.BookId);
            await _barrowBookBusinessRules.UserIsExists(barrowBookDto.UserId);
            await _barrowBookBusinessRules.BookAlreadyBarrowed(barrowBookDto.Id);
            // Validation _barrowBookBusinessRules.BarrowEndTimeCantBeEqualsOrLessThanBarrowStartDate(barrowStartDate:barrowBookDto.BarrowStartDate, barrowEndDate:barrowBookDto.BarrowEndDate);
            BarrowedBook mappedBarrowBook = _mapper.Map<BarrowedBook>(barrowBookDto);
            var addedBb=_barrowedBookWriteRepository.Add(mappedBarrowBook);
            await _barrowedBookWriteRepository.SaveAsync();
            return addedBb;
        }


        public async Task<bool> DeleteBarrowedBook(BarrowedBook barrowedBook)
        {
            await _barrowBookBusinessRules.BarrowIsExists(barrowedBook.Id);
            await _barrowBookBusinessRules.NotAllowedUntilBookAtBarrow(barrowedBook.Id);
            bool isRemoved = _barrowedBookWriteRepository.Remove(barrowedBook);
            await _barrowedBookWriteRepository.SaveAsync();
            return isRemoved;
        }

        public async Task<BarrowedBook> UpdateABarrow(BarrowBookDto barrowedBook)
        { 
            await _barrowBookBusinessRules.BarrowIsExists(barrowedBook.Id);
            await _barrowBookBusinessRules.UserIsExists(barrowedBook.UserId);
            await _barrowBookBusinessRules.BookIsExists(barrowedBook.BookId);
            BarrowedBook mappedBook = _mapper.Map<BarrowedBook>(barrowedBook);
            var updatedBb= _barrowedBookWriteRepository.Update(mappedBook);
            await _barrowedBookWriteRepository.SaveAsync();
            return updatedBb;
        }
    }
}
