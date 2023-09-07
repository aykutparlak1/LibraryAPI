﻿using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using LibraryAPI.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Commands.CreateAuthor
{
    public class CreateAuthorCommandRequest: IRequest<CreatedAuthorDto> // where T : class , IDto, new()
    {

        //public T Dto { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
