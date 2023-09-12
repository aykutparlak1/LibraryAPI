namespace LibraryAPI.Application.Dtos
{
    public class ObtainedAuthorDto
    {
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }

        public string FullName => $"{AuthorFirstName} {AuthorLastName}";
    }
}
