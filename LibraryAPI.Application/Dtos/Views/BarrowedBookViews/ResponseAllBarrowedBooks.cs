using LibraryAPI.Domain.Entities.BookEntites;

namespace LibraryAPI.Application.Dtos.Views.BarrowedBookViews
{
    public class ResponseAllBarrowedBooks
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }

        public string BookName { get; set; }
        public List<string> AuthorName { get; set; }
        public string CategoryName { get; set; }

        public string PublisherName { get; set; }

    }
}
