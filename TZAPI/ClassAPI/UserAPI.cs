using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TZASPART;

namespace TZAPI.ClassAPI
{
    public class UserAPI : InterfaseAPI.IUserAPI
    {
        public async Task<User> GetInfoAsync(string x)
        {
            User? Data = null;
            try
            {
                await using (TZARTDBContext v = new TZARTDBContext())
                {
                    Data = await v.Users.Where(p => p.Phone.Equals(x)).FirstOrDefaultAsync();
                }
                return Data;
            }
            catch
            {
                return Data;
            }
        }
    }
}
