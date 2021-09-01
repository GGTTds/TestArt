using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TZASPART.Interface
{
    interface IUserRepository
    {
        public Task<bool> RegisUserAsync(User x);
        public Task<bool> LoginInAsync(string log, string pas);
        public Task<List<User>> GetDataUserAsync(string x);
    }
}
