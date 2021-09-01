using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TZASPART.Controllers
{
    public class CabinetController : Controller
    {
        ActionClass.UserRepository b1 = new ActionClass.UserRepository();
        public async Task<ActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SAS")))
            {
                return StatusCode(401);
            }
            return View(await b1.GetDataUserAsync(HttpContext.Session.GetString("SAS")));
        }
        // GET: CabinetController/Create
        public ActionResult Exit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Register", "Account");
        }

        // POST: CabinetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CabinetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CabinetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CabinetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CabinetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
