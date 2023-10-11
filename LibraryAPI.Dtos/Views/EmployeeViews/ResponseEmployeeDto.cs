namespace LibraryAPI.Dtos.Views.EmployeeViews
{
    public class ResponseEmployeeDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoPath { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public bool IsActive { get; set; }
    }
}
