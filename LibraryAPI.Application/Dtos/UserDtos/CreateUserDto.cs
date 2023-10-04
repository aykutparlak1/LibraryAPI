namespace LibraryAPI.Application.Dtos.UserDtos
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public long IdentityNumber { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
