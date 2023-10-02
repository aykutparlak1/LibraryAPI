using AutoMapper;
using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Dtos.UserDtos;
using LibraryAPI.Application.Features.AuthFeatures.Commands.RegisterUser;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor;
using LibraryAPI.Application.Features.UserFeatures.Queries.GetAllUserQuerry;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Domain.Entities.UserEntities;

namespace LibraryAPI.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Author, CommandAuthorDto>().ReverseMap();
            CreateMap<Author, CreateAuthorCommandRequest>().ReverseMap();

            CreateMap<Author, ObtainedAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommandRequest>().ReverseMap();

            CreateMap<CreateUserDto, RegisterUserCommandRequest>().ReverseMap();


            CreateMap<Author, DeleteAuthorCommandRequest>().ReverseMap();
            CreateMap<User, GetAllUserQuerryRequest>().ReverseMap();
            CreateMap<User , ReadUserDto>().ReverseMap();
        }
    }
}
