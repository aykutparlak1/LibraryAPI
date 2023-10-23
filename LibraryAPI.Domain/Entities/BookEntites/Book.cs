using LibraryAPI.Domain.Entities.BarrowEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class Book : BaseEntity
    {
        public Book()
        {
            Authors = new HashSet<BookAuthor>();
            BarrowedBooks = new HashSet<BarrowedBook>();

        }
        public int Id { get; set; }
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
