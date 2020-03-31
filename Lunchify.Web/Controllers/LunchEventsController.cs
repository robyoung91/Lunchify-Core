using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lunchify.Data.Models;
using Lunchify.Data.Services;
using Lunchify.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lunchify.Web.Controllers
{
    public class LunchEventsController : Controller
    {
        IAppData db;

        public LunchEventsController(IAppData db)
        {
            this.db = db;
        }
        // GET: LunchEvents
        public ActionResult Index()
        {
            var model = db.GetAllLunchEvents();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = db.GetLunchEvent(id);
            if (model == null)
            {
                return View("NotFound");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new LunchEventViewModel
            {
                UserSelectList = new SelectList(db.GetAllUsers().ToList(), "Id", "Name").Prepend(new SelectListItem
                {
                    Value = "-1",
                    Text = "Select a host",
                }
                ),
                LunchSelectList = new SelectList(db.GetAllLunches().ToList(), "Id", "Name"),
            };

            model.UserSelectList.Append(new SelectListItem
            {
                Value = "-1",
                Text = "Select a host",
            }
            );

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LunchEventViewModel lunchEventViewModel)
        {

            if (ModelState.IsValid)
            {
                lunchEventViewModel.LunchEvent = new LunchEvent()
                {
                    Host = db.GetUser(lunchEventViewModel.SelectedUserId),
                    Lunch = db.GetLunch(lunchEventViewModel.SelectedLunchId),
                    Location = lunchEventViewModel.Location,
                    Capacity = lunchEventViewModel.Capacity,
                };

                db.CreateLunchEvent(lunchEventViewModel.LunchEvent);
                return RedirectToAction("Details", new { id = lunchEventViewModel.LunchEvent.Id });
            }

            return Create();
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lunchEvent = db.GetLunchEvent(id);

            var model = new LunchEventViewModel
            {
                LunchEvent = lunchEvent,
                SelectedUserId = lunchEvent.Host.Id,
                SelectedLunchId = lunchEvent.Lunch.Id,
                Location = lunchEvent.Location,
                Capacity = lunchEvent.Capacity,
                UserSelectList = new SelectList(db.GetAllUsers().ToList(), "Id", "Name"),
                LunchSelectList = new SelectList(db.GetAllLunches().ToList(), "Id", "Name"),
            };

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(LunchEventViewModel lunchEventViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                lunchEventViewModel.LunchEvent = new LunchEvent()
                {
                    Id = id,
                    Host = db.GetUser(lunchEventViewModel.SelectedUserId),
                    Lunch = db.GetLunch(lunchEventViewModel.SelectedLunchId),
                    Location = lunchEventViewModel.Location,
                    Capacity = lunchEventViewModel.Capacity,
                };

                db.UpdateLunchEvent(lunchEventViewModel.LunchEvent);
                TempData["Message"] = "You have saved the event!";
                return RedirectToAction("Details", new { id = lunchEventViewModel.LunchEvent.Id });
            }

            return Edit(id);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.GetLunchEvent(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LunchEvent lunchEvent)
        {
            db.DeleteLunchEvent(lunchEvent.Id);
            return RedirectToAction("Index");
        }
    }
}