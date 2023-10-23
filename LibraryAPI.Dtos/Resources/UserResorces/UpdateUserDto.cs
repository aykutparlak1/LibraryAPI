namespace LibraryAPI.Dtos.Resources.UserResorces
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public int UserType { get; set; } // default olarak customer olarak kayıt olcak // false is customer
        public bool? Status { get; set; }
    }
}
