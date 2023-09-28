using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public DateTime CreatedTime { get; set; }

        public DateTime UpdatingTime { get; set; }
        public byte[]? RowVersion { get; set; }
    }
}
