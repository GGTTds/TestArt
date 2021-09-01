using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TZASPART.ActionClass
{
    public class AccountManager : Interface.ILogic
    {
       
        public async Task<bool> ValidPhone(string x)
        {
                bool t = false;
                try
                {
                    await using (TZARTDBContext v = new TZARTDBContext())
                    {
                         User? g = await v.Users.Where(p => p.Phone.Equals(x)).FirstOrDefaultAsync();
                        if(g == null)
                        {
                            t = true;
                        }
                        else
                        {
                            t = false;
                        }
                    }
                    return t;
                }
                catch
                {
                    return false;
                }
           
        }
        public async Task<bool> ValidEmail(string x)
        {
                bool t = false;
                try
                {
                    await using (TZARTDBContext v = new TZARTDBContext())
                    {
                        User? g1 = await v.Users.Where(p => p.Email.Equals(x)).FirstOrDefaultAsync();
                        if (g1 == null)
                        {
                            t = true;
                        }
                        else
                        {
                            t = false;
                        }
                    }
                    return t;
                }
                catch
                {
                    return false;
                }
            

        }
                public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
                string DomainMapper(Match match)
                {
                    var idn = new System.Globalization.IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }


    }
