using AutoMapper;
using LibraryAPI.Application.Dtos.Resources.AuthorResources;
using LibraryAPI.Application.Dtos.Resources.UserResorces;
using LibraryAPI.Application.Dtos.Views.BarrowedBookViews;
using LibraryAPI.Application.Dtos.Views.BookViews;
using LibraryAPI.Application.Dtos.Views.CategoryViews;
using LibraryAPI.Application.Dtos.Views.PublisherViews;
using LibraryAPI.Application.Dtos.Views.UserViews;
using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.MapProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            
            CreateMap<User, ResponseAllUserDto>()
                .ReverseMap();
            //CreateMap<List<User>, List<ResponseAllUserDto>>().ReverseMap();

            CreateMap<User, CreateUserDto>().ReverseMap();

            //CreateMap<List<User>, List<ResponseAllUserWhereCustomerDto>>().ReverseMap();
            //CreateMap<List<User>, List<ResponseAllUserWhereEmployeDto>>().ReverseMap();

            CreateMap<Book, ResponseBook>().ForMember(x=>x.AuthorName, opt=>opt.MapFrom(src=>src.Authors))
                .ForMember(x=>x.PublisherName, opt=>opt.MapFrom(src=>src.Publisher.PublisherName))
                .ForMember(x=>x.CategoryName, opt=>opt.MapFrom(src=>src.Category.CategoryName))
                .ReverseMap();
            

            //CreateMap<List<Book>, List<ResponseBook>>().ReverseMap();


            CreateMap<BarrowedBook, ResponseAllBarrowedBooks>()
                .ForMember(x=>x.AuthorName, opt=>opt.MapFrom(src=>src.Book.Authors))
                .ForMember(x=>x.PublisherName, opt=>opt.MapFrom(src=>src.Book.Publisher))
                .ForMember(x=>x.CategoryName, opt=>opt.MapFrom(src=>src.Book.Category))
                .ReverseMap();
            //CreateMap<List<BarrowedBook>, List<ResponseAllBarrowedBooks>>()
            //    .ReverseMap();
            


            
            CreateMap<Category,ResponseCategoryDto>().ReverseMap();

            //CreateMap<List<Category>, List<ResponseCategoryDto>>().ReverseMap();
            CreateMap<Publisher, ResponsePublisherDto>().ReverseMap();
            //CreateMap<List<Publisher>, List<ResponsePublisherDto>>().ReverseMap();


            CreateMap<Author, CreateAuthorDto>().ReverseMap();
        }
    }
}
