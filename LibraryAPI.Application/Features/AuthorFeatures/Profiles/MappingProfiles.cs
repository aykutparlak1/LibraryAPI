using AutoMapper;
using LibraryAPI.Application.Dtos.AuthorDtos;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.DeleteAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.UpdateAuthor;

using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAuthorByIWT;
using LibraryAPI.Domain.Entities.BookEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Profiles
{
    public class MappingProfiles : Profile
    {
       public MappingProfiles()
        {
            CreateMap<Author,CommandAuthorDto>().ReverseMap();
            CreateMap<Author,CreateAuthorCommandRequest>().ReverseMap();

            CreateMap<Author, ObtainedAuthorDto>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommandRequest>().ReverseMap();


            CreateMap<Author, DeleteAuthorCommandRequest>().ReverseMap();
        }
    }
}
