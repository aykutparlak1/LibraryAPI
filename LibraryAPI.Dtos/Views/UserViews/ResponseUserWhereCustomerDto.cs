namespace LibraryAPI.Dtos.Views.UserViews
{
    public class ResponseUserWhereCustomerDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public DateTime? SubStartDate { get; set; }
        public DateTime? SubEndDate { get; set; }
        public bool IsSub { get; set; }

    }
}
