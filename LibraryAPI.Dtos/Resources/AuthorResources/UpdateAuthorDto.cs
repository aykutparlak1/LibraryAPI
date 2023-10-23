using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Dtos.Resources.AuthorResources
{
    public class UpdateAuthorDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
    }
}
