using LibraryAPI.Application.Features.AuthorFeatures.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Models
{
    public class ObtainedAuthorListModel
    {
        public IList<ObtainedAuthorListDto> Items { get; set; }
    }
}
