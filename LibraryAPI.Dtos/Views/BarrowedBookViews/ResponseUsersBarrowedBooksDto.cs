using LibraryAPI.Dtos.Views.AuthorViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Dtos.Views.BarrowedBookViews
{
    public class ResponseUsersBarrowedBooksDto
    {
        public string BookName { get; set; }
        public List<ResponseAuthorDto> Authors { get; set; }
        public string CategoryName { get; set; }

        public string PublisherName { get; set; }
    }
}
