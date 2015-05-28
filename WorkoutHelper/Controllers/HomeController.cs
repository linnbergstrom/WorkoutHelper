using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkoutHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			//var menuItems = new[] { "Start workout", "Add Workout", "Planned Workout", "My Calender", "My Workouts" };
			//ViewBag.MenueItems = menuItems;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}