using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lunchify.Web.Models;
using Lunchify.Data.Services;

namespace Lunchify.Web.Controllers
{
    public class HomeController : Controller
    {
        IAppData db;

        public HomeController(IAppData db)
        {
            this.db = db;
        }
        public ActionResult Index()
        {
            var model = db.GetAllUsers();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
