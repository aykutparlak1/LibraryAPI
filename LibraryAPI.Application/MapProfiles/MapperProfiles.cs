using AutoMapper;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Resources.AuthorResources;
using LibraryAPI.Dtos.Resources.UserResorces;

namespace LibraryAPI.Application.MapProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {

            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Author, CreateAuthorDto>().ReverseMap();

        }
    }
}
