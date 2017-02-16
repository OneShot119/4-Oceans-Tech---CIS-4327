using HopeTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HopeTherapy.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        [HttpGet]
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var days = Utilities.Sql.ExecuteQuery<Day>("SELECT Day as day, FirstName as fname, LastName as lname FROM Days JOIN Volunteer ON Days.Volunteer = Volunteer.VolunteerID");
                return View(days);
            }
        }
    }
}