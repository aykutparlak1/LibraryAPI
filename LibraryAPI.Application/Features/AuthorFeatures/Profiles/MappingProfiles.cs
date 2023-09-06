using AutoMapper;
using LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor;
using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using LibraryAPI.Application.Features.AuthorFeatures.Models;
using LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor;
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
            CreateMap<Author,CreatedAuthorDto>().ReverseMap();
            CreateMap<Author,CreateAuthorCommandRequest>().ReverseMap();

            CreateMap<Author,ObtainedAuthorListDto>().ReverseMap();
            CreateMap<IList<Author>,ObtainedAuthorListModel>().ReverseMap();



        }
    }
}
