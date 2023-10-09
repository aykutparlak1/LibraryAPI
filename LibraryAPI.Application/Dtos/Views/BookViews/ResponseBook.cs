namespace LibraryAPI.Application.Dtos.Views.BookViews
{
    public class ResponseBook
    {
        public string BookName { get; set; }
        public List<string> AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
        public int NumberOfPages { get; set; }
        public string Location { get; set; }
    }
}
