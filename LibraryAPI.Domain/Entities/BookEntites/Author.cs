using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class Author : BaseEntity
    {
        public Author()
        {
            Books = new HashSet<BookAuthor>();
        }
        public int Id { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public ICollection<BookAuthor> Books { get; set; }
    }
}
