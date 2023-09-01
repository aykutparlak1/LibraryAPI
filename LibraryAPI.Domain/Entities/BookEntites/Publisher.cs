using LibraryAPI.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class Publisher : IEntity
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public int PublisherName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
