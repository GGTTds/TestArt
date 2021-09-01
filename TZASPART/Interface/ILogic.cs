using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TZASPART.Interface
{
    public interface ILogic
    {
        public Task<bool> ValidPhone(string x);
        public Task<bool> ValidEmail(string x);
        public bool IsValidEmail(string email);
    }
}
