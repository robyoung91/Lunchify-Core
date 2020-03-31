using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lunchify.Data.Models;
using Lunchify.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lunchify.Web.Controllers
{
    public class UsersController : Controller
    {
        IAppData db;

        public UsersController(IAppData db)
        {
            this.db = db;
        }
        // GET: Users
        public ActionResult Index()
        {
            var model = db.GetAllUsers();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetUser(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.CreateUser(user);
                return RedirectToAction("Details", new { id = user.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetUser(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.UpdateUser(user);
                TempData["Message"] = "You have saved the user!";
                return RedirectToAction("Details", new { id = user.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetUser(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(User user)
        {
            db.DeleteUser(user.Id);
            return RedirectToAction("Index");
        }
    }
}