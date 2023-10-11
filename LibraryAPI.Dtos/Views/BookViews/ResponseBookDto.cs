using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Dtos.Views.BookViews
{
    public class ResponseBookDto
    {
        public string BookName { get; set; }
        public List<ResponseAuthorDto> Authors { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public int NumberOfPages { get; set; }
        public string Location { get; set; }
    }
}
