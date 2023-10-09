using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Services.ReadServices.UserReadService
{
    public interface IUserOperationClaimReadService
    {
        public bool IsInRole(int id);
    }
}
