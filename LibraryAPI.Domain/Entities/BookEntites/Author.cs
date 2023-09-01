using LibraryAPI.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class Author : IEntity
    {
        public Author()
        {
            Books = new HashSet<BookAuthor>();
        }
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public ICollection<BookAuthor> Books { get; set; }
    }
}
