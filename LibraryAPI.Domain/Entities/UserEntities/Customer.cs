using LibraryAPI.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities.UserEntities
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? SubStartDate { get; set; }
        public DateTime? SubEndDate { get; set; }
        public bool IsSub { get; set; }
        public User? User { get; set; }
    }
}
