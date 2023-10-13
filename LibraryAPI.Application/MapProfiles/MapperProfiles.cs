using AutoMapper;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.AuthorResources;
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
            CreateMap<Author, CreateAuthorDto>().ReverseMap();
            CreateMap<Publisher,AddPublisherDto>().ReverseMap();
            CreateMap<Category,AddCategoryDto>().ReverseMap();
            CreateMap<Book,AddBookDto>().ReverseMap();

        }
    }
}
