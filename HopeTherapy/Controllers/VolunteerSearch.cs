using HopeTherapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HopeTherapy.DataAccess;
using System.Data.SqlClient;
using System.Configuration;

namespace HopeTherapy.Controllers
{
    public class VolunteerSearchController : Controller
    {
        // GET: Volunteer
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Volunteer model)
        {

            var Volunteer = new Volunteer();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult List()
        {
            var Volunteers = Utilities.Sql.ExecuteQuery<Volunteer>("select FirstName as FirstName, LastName as LastName");
            return View(Volunteers);

        }
    }

}