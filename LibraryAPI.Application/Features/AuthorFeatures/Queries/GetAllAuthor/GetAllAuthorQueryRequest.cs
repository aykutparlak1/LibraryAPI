﻿using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Queries.GetAllAuthor
{
    public class GetAllAuthorQueryRequest :IRequest<ICollection<ObtainedAuthorDto>>
    {
    }
}
