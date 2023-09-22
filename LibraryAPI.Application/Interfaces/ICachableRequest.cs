using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Interfaces
{
    public interface ICachableRequest
    {
        string CacheKey { get; }
        TimeSpan? SlidingExpiration { get; }
    }
}
