namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class Author : BaseEntity
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
