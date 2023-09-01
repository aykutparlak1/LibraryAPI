using LibraryAPI.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class BookAuthor : IEntity
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
