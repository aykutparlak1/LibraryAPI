namespace LibraryAPI.Domain.Entities.BookEntites
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
