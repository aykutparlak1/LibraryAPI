using AutoMapper;
using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            


            CreateMap<Author, CommandAuthorDto>().ReverseMap();


            CreateMap<Author, ObtainedAuthorDto>().ReverseMap();




            CreateMap<User , ReadUserDto>().ReverseMap();
        }
    }
}
