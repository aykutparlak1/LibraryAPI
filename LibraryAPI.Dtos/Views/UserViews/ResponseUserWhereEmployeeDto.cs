using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Dtos.Views.UserViews
{
    public class ResponseUserWhereEmployeeDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long IdentityNumber { get; set; }
        public DateTime? BirthDate { get; set; }

        public int? PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Status { get; set; }
        public string Title { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? LeaveDate { get; set; }
        public bool IsActive { get; set; }

    }
}
