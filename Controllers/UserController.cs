using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCWebProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebProject.Controllers
{
    public class UserController : Controller
    {

        UserDAL ud = new UserDAL();
        // GET: UserController
        public ActionResult Index()
        {
            var model = ud.GetAllUsers();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            User u = ud.GetUserById(id);
            return View(u);
        }

        // GET: UserController/Create

        public ActionResult SignUp()
        {
                return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User u)
        {
            try
            {
                ud.Save(u);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            User u = ud.GetUserById(id);
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User u)
        {
            try
            {
                ud.Update(u);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            User u = ud.GetUserById(id);
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                ud.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
