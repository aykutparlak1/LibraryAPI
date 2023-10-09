namespace LibraryAPI.Application.Dtos.Resources.UserResorces
{
    public class UpdateUserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoPath { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
