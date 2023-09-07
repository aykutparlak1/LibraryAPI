using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Features.AuthorFeatures.Dtos
{
    public class ObtainedAuthorDto
    {
        public string AuthorFirstName {  get; set; }
        public string AuthorLastName { get; set; }

        public string FullName => $"{AuthorFirstName} {AuthorLastName}";
    }
}
