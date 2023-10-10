using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Dtos.Views.UserViews
{
    public class ResponseAllUserWhereEmployeDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PhotoPath { get; set; }
        public int UserType { get; set; }
        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public string Title { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime LeaveTime { get; set; }
        public bool IsActive { get; set; }

    }
}
