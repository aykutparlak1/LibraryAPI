using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Dtos.AuthorDtos
{
    public class CreateAuthorDto
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
