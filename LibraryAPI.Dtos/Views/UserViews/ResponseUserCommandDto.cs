namespace LibraryAPI.Dtos.Views.UserViews
{
    public class ResponseUserCommandDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
    }
}
