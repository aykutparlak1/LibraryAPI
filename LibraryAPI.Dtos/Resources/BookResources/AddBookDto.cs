using LibraryAPI.Dtos.Views.AuthorViews;

namespace LibraryAPI.Dtos.Resources.BookResources
{
    public class AddBookDto
    {
        public string BookName { get; set; }
        public List<ResponseAuthorDto> Authors { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public int NumberOfPages { get; set; }
        public string Location { get; set; }
    }
}
