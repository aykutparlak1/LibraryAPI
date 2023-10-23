using AutoMapper;
using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.AuthorResources;
using LibraryAPI.Dtos.Resources.BarrowBookResources;
using LibraryAPI.Dtos.Resources.BookResources;
using LibraryAPI.Dtos.Resources.CategoryResources;
using LibraryAPI.Dtos.Resources.PublisherResources;
using LibraryAPI.Dtos.Resources.UserResorces;

namespace LibraryAPI.Application.MapProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {

            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<AddAuthorDto, Author>().ReverseMap()
                .ForMember(x=>x.AuthorName, opt=>opt.MapFrom(x => x.AuthorName));
            CreateMap<Author, AuthorIds>().ReverseMap()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.AuthorId));
            CreateMap<BookAuthor, AuthorIds>().ReverseMap()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId));
            CreateMap<Author, UpdateAuthorDto>().ReverseMap();
            CreateMap<Publisher,AddPublisherDto>().ReverseMap();
            CreateMap<Publisher,UpdatePublisherDto>().ReverseMap();
            CreateMap<Category,AddCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Book,AddBookDto>().ReverseMap()
                .ForMember(x=>x.Authors, opt=>opt.MapFrom(x=>x.Authors));
            CreateMap<Book,UpdateBookDto>().ReverseMap();
            CreateMap<BarrowedBook,BarrowBookDto>().ReverseMap();

        }
    }
}
