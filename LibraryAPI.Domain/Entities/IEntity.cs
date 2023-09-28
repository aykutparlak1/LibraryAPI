using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Domain.Entities
{
    public interface IEntity
    {
        DateTime CreatedTime { get; set; }
        DateTime UpdatingTime { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
