using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TZASPART.Controllers
{
    public class AccountController : Controller
    {
        public static string FioThis;
        ActionClass.AccountManager b = new ActionClass.AccountManager();
        ActionClass.UserRepository b1 = new ActionClass.UserRepository();
        public ActionResult Register()
        {
            return View();
        }

        // POST
        [HttpPost]
        public async Task<ActionResult> Register(User x)
        {
            try
            {
                if (x.Phone.StartsWith("7") == true)
                {
                    bool ExpBDPhone = await b.ValidPhone(x.Phone);
                    if (ExpBDPhone == false)
                    {
                        ModelState.AddModelError("Phone", "Некорректный телефон");
                    }
                }
                else
                {
                    ModelState.AddModelError("Phone", "телефон должен начинаться с 7");
                }
                if(x.Password.Length < 20)
                {
                    ModelState.AddModelError("Password", "Пароль слишком кароткий");
                }
                if (b.IsValidEmail(x.Email) == true)
                {
                    bool ExpBDEmail = await b.ValidEmail(x.Email);
                    if (ExpBDEmail == false)
                    {
                        ModelState.AddModelError("Email", "Такой email уже существует");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Неккоректный Email");
                }
                if (ModelState.IsValid == false)
                {
                    return View();
                }
                else
                {
                    x.LastLogin = DateTime.Now;
                    await b1.RegisUserAsync(x);
                    FioThis = x.Fio;
                    return RedirectToAction("AndReg");
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(User y)
        {
            try
            {
                if (y.Phone.StartsWith("7") == true)
                {
                    bool ThisControlData = await b1.LoginInAsync(y.Phone, y.Password);
                    if (ThisControlData == true)
                    {
                        HttpContext.Session.SetString("SAS", y.Phone);
                        return RedirectToAction("Index","Cabinet");
                    }
                    else
                    {
                        ModelState.AddModelError("Phone", "Ошибка авторизации");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("Phone", "телефон должен начинаться с 7");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult AndReg()
        {
            ViewBag.Meessag = FioThis;
            return View();
        }
       
      
    }

}
