using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TZASPART;

namespace TZAPI.InterfaseAPI
{
     public interface IUserAPI
    {
        public Task<User> GetInfoAsync(string x);
    }
}
