﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Application.Interfaces
{
    public interface ICacheRemoveRequest
    {
       string CacheGroup { get; } 
    }
}
