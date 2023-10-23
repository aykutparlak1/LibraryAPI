using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Dtos.Views.BarrowedBookViews
{
    public class ResponseAllBarrowedBooksDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }

        public string BookName { get; set; }
        public List<ResponseAuthorDto> Authors { get; set; }
        public string CategoryName { get; set; }

        public string PublisherName { get; set; }

    }
}
