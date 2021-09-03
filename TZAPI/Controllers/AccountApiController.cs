using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TZASPART.ActionClass;
using TZASPART;

namespace TZAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        AccountManager b = new AccountManager();
        UserRepository b1 = new UserRepository();
        ClassAPI.UserAPI b2 = new ClassAPI.UserAPI();
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User x)
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
                if (x.Password.Length < 20)
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
                    return BadRequest(ModelState);
                }
                else
                {
                    x.LastLogin = DateTime.Now;
                    await b1.RegisUserAsync(x);
                    return StatusCode(200);
                }
            }
            catch
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        public async Task<ActionResult> Login([FromBody] User y)
        {
            try
            {
                if (y.Phone.StartsWith("7") == true)
                {
                    bool ThisControlData = await b1.LoginInAsync(y.Phone, y.Password);
                    if (ThisControlData == true)
                    {
                        Response.Cookies.Append("SAS", y.Phone);
                        return StatusCode(200);
                    }
                    else
                    {
                        ModelState.AddModelError("Phone", "Ошибка авторизации");
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    ModelState.AddModelError("Phone", "телефон должен начинаться с 7");
                    return BadRequest(ModelState);
                }
            }
            catch
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete]
        public ActionResult logout()
        {
            if (Request.Cookies.ContainsKey("SAS") == false)
            {
                return StatusCode(400);
            }
            else
            {
                Response.Cookies.Delete("SAS");
                return StatusCode(200);
            }
        }
        [HttpGet]
        [Route("get-my-info")]
        public async Task<ActionResult<User>> GetInfo()
        {
            if (Request.Cookies.ContainsKey("SAS") == false)
            {
                return StatusCode(400);
            }
            else
            {
                return await b2.GetInfoAsync(Request.Cookies["SAS"]);
            }
        }
    }
}
