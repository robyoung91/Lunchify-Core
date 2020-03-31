using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lunchify.Data.Models;
using Lunchify.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lunchify.Web.Controllers
{
    public class LunchesController : Controller
    {
        IAppData db;

        public LunchesController(IAppData db)
        {
            this.db = db;
        }
        // GET: Lunches
        public ActionResult Index()
        {
            var model = db.GetAllLunches();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetLunch(id);
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
        public ActionResult Create(Lunch lunch)
        {
            if (ModelState.IsValid)
            {
                db.CreateLunch(lunch);
                return RedirectToAction("Details", new { id = lunch.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.GetLunch(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Lunch lunch)
        {
            if (ModelState.IsValid)
            {
                db.UpdateLunch(lunch);
                TempData["Message"] = "You have saved the lunch!";
                return RedirectToAction("Details", new { id = lunch.Id });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetLunch(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Lunch lunch)
        {
            db.DeleteLunch(lunch.Id);
            return RedirectToAction("Index");
        }
    }
}