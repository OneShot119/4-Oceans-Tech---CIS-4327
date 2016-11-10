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
    public class DonorController : Controller
    {
        // GET: Donor
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Donor model)
        {

            // Todo: Check database
            return View(model);
        }
    }
}