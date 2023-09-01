using LibraryAPI.Domain.Entities.BarrowEntites;
using LibraryAPI.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class Book : IEntity
    {
        public Book()
        {
            Authors = new HashSet<BookAuthor>();
        }
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public string BookName { get; set; }
        public int NumberOfPages { get; set; }
        public string Location { get; set; }
        public ICollection<BookAuthor> Authors { get; set; }
        public Category Category { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<BarrowedBook> BarrowedBooks { get; set; }
    }
}
