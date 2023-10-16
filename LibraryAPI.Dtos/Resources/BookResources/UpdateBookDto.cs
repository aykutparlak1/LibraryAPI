using LibraryAPI.Dtos.Views.AuthorViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Dtos.Resources.BookResources
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public List<AuthorIds> Authors { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public int NumberOfPages { get; set; }
        public string Location { get; set; }
    }
}
