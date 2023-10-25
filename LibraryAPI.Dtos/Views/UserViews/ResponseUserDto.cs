namespace LibraryAPI.Dtos.Views.UserViews
{
    public class ResponseUserDto
    {
        public int Id { get; set; }
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
