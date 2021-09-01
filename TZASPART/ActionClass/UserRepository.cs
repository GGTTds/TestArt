using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TZASPART.ActionClass
{
    public class UserRepository : Interface.IUserRepository
    {
        public async Task<bool> RegisUserAsync(User x)
        {
            try
            {
                await using (TZARTDBContext v = new TZARTDBContext())
                {
                    await v.Users.AddAsync(x);
                    await v.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> LoginInAsync(string log, string pas)
        {
            try
            {
                await using (TZARTDBContext b = new TZARTDBContext())
                {
                    User? v = await b.Users.Where(p => p.Phone.Equals(log)).Where(p => p.Password.Equals(pas)).FirstOrDefaultAsync();
                    if (v == null)
                    {
                        return false;
                    }
                    else
                    {
                        v.LastLogin = DateTime.Now;
                        b.Update(v);
                        await b.SaveChangesAsync();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

        }
        public async Task<List<User>> GetDataUserAsync(string x)
        {
           await using (TZARTDBContext b = new TZARTDBContext())
            {
                return await b.Users.Where(p => p.Phone.Equals(x)).ToListAsync();
            }
        }
    }
}
